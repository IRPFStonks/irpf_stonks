using IRPFStonks.Inputs.Excel;
using NUnit.Framework;

namespace IRPFStonks.Inputs.NUnit.Excel
{
    [TestFixture]
    internal sealed class ExcelImporterFixture : ExcelReaderBaseFixture
    {

        [Test]
        public async Task CanImportFile()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao.xlsx");
            
            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.True);
                Assert.That(importResult.ImportErrors, Is.Empty);
            });
        }
    }
}
