using System.Data;
using System.Text;

// Excel Reader Project
// https://github.com/ExcelDataReader/ExcelDataReader

namespace ExcelDataReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Fix for the ExcelDataReader in .NET Core
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Console.WriteLine("Lendo Arquivo Excel de Teste");
            Console.WriteLine("B3 Movimentação");

            ReadExcelFile();
        }

        private static void ReadExcelFile()
        {
            using (var stream = File.Open("./movimentacao.xlsx", FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet();

                    Console.WriteLine($"Número de Spreadsheets: {result.Tables.Count}");
                    Console.WriteLine($"Número de Colunas: {result.Tables[0].Columns.Count}");
                    Console.WriteLine($"Número de Linhas: {result.Tables[0].Rows.Count}");
                    Console.WriteLine($"Planilha Output");
                    Console.WriteLine();

                    // Loop Rows
                    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                    {
                        StringBuilder outputRow = new();

                        // Loop columns and 
                        for (int j = 0; j < result.Tables[0].Columns.Count; j++)
                        {
                            outputRow.Append($"{result.Tables[0].Rows[i][j]}\t");
                        }

                        Console.WriteLine(outputRow.ToString());
                    }
                }
            }
        }
    }
}