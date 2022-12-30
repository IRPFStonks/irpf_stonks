using IRPFStonks.BusinessLogic.Model.Movement;
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

                Assert.That(importResult.ImportedData[0], Is.Not.Null);
                Assert.That(importResult.ImportedData, Has.Count.EqualTo(9));
                var firstRecord = importResult.ImportedData[0];

                Assert.That(firstRecord.Direction, Is.EqualTo(MovementDirection.Credit));
                Assert.That(firstRecord.Date, Is.EqualTo(new DateTime(2021, 12, 30)));
                Assert.That(firstRecord.Type, Is.EqualTo(MovementType.Jcp));
                Assert.That(firstRecord.StockCode, Is.EqualTo("BBDC4"));
                Assert.That(firstRecord.StockCompany, Is.EqualTo("BANCO BRADESCO S/A"));
                Assert.That(firstRecord.Quantity, Is.EqualTo(56d));
                Assert.That(firstRecord.UnityPrice, Is.EqualTo(0.02));
                Assert.That(firstRecord.TotalPrice, Is.EqualTo(1.03));

            });
        }

        [Test]
        public async Task CanNotImport_WrongHeader()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_WrongHeader.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);
                Assert.That(importResult.ImportErrors, Contains.Substring("Stock não pertence ao cabeçalho padrão."));
                Assert.That(importResult.ImportErrors, Contains.Substring("Preço não pertence ao cabeçalho padrão."));
            });
        }

        [Test]
        public async Task CanNotImport_NoHeader()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_NoHeader.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);
                Assert.That(importResult.ImportErrors, Contains.Substring("Cabeçalho não encontrado."));
            });
        }

        [Test]
        public async Task CanNotImport_InvalidDate()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_InvalidDate.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);
                
                // At this point i'm not interested in the error message
                Assert.That(importResult.ImportErrors, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CanNotImport_InvalidMovimentType()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_InvalidMovimentType.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);

                // At this point i'm not interested in the error message
                Assert.That(importResult.ImportErrors, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CanNotImport_InvalidMovimentDirection()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_InvalidMovimentDirection.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);

                // At this point i'm not interested in the error message
                Assert.That(importResult.ImportErrors, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CanNotImport_InvalidUnitPrice()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_InvalidUnitPrice.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);

                // At this point i'm not interested in the error message
                Assert.That(importResult.ImportErrors, Is.Not.Empty);
            });
        }

        [Test]
        public async Task CanNotImport_InvalidTotalPrice()
        {
            var excelImporter = new ExcelImporter();

            var importResult = await excelImporter.ImportFileAsync("./NUnitFiles/movimentacao_InvalidTotalPrice.xlsx");

            Assert.Multiple(() =>
            {
                Assert.That(importResult.IsSuccessful, Is.False);

                // At this point i'm not interested in the error message
                Assert.That(importResult.ImportErrors, Is.Not.Empty);
            });
        }
    }
}
