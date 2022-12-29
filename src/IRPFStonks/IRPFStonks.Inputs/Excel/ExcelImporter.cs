using ExcelDataReader;
using IRPFStonks.BusinessLogic.Model.Movement;
using System.Collections.Immutable;
using System.Data;
using System.Globalization;
using System.Text;

namespace IRPFStonks.Inputs.Excel
{
    public class ExcelImporter : IFileImporter<StockMovement>
    {
        public Task<ImportResult<StockMovement>> ImportFileAsync(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet excelDataSet = reader.AsDataSet();

                    foreach (DataTable table in excelDataSet.Tables)
                    {
                        string validation = ValidateHeaders(table.Rows);

                        if (string.IsNullOrEmpty(validation))
                        {
                            StringBuilder readingErrors = new StringBuilder();
                            List<StockMovement> stockMovements = new();
                            bool skipHeaders = true;

                            foreach (DataRow item in table.Rows)
                            {
                                if (skipHeaders)
                                {
                                    skipHeaders = false;
                                    continue;
                                }

                                try
                                {
                                    var productParts = item.Field<string>(ExpectedHeader.StockCode.Value)!.Split(new[] { '-' });

                                    stockMovements.Add(new StockMovement(MovementDirection.FromName(item.Field<string>(ExpectedHeader.MovementDirection.Value)),
                                        DateTime.Parse(item.Field<string>(ExpectedHeader.Date.Value), CultureInfo.CreateSpecificCulture("pt-BR")),
                                        MovementType.FromName(item.Field<string>(ExpectedHeader.MovementType.Value)),
                                        productParts[0].Trim(),
                                        productParts[1].Trim(),
                                        item.Field<string>(ExpectedHeader.Institution.Value),
                                        item.Field<double>(ExpectedHeader.Quantity.Value),
                                        item.Field<double>(ExpectedHeader.UnitPrice.Value),
                                        item.Field<double>(ExpectedHeader.TotalPrice.Value)));


                                }
                                catch (Exception ex)
                                {
                                    readingErrors.AppendLine(ex.ToString());
                                }

                            }

                            if (readingErrors.Length > 0)
                            {
                                return Task.FromResult(new ImportResult<StockMovement>(false, $"{readingErrors}", null));
                            }
                            else
                            {
                                return Task.FromResult(new ImportResult<StockMovement>(true, $"{readingErrors}", stockMovements.ToImmutableList()));
                            }
                        }

                        return Task.FromResult(new ImportResult<StockMovement>(false, validation, null));

                    }
                }
            }

            return Task.FromResult(new ImportResult<StockMovement>(true, string.Empty, null));

        }

        private static string ValidateHeaders(DataRowCollection rows)
        {
            StringBuilder errors = new();

            for (int i = 0; i < ExpectedHeader.List.Count; i++)
            {
                var header = rows[0][i].ToString();

                if (header is null)
                {
                    return errors.AppendLine("Cannot find headers").ToString();
                }

                ExpectedHeader.TryFromName(header, true, out var value);

                if (value is null)
                {
                    errors.AppendLine($"{header} does belong to the expected header");
                }
            }

            if (errors.Length > 0)
            {
                return errors.ToString();
            }

            return string.Empty;
        }
    }
}
