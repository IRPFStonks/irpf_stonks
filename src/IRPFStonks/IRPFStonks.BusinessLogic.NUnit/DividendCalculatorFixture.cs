using IRPFStonks.BusinessLogic.Model;
using System.Collections.Immutable;

namespace IRPFStonks.BusinessLogic.NUnit
{
    [TestFixture]
    internal sealed class DividendCalculatorFixture
    {
        private ImmutableList<StockMovement> _StockMoviments;

        [SetUp]
        public void Setup()
        {
            _StockMoviments = ImmutableList.Create(new StockMovement("Credito", new DateTime(2021, 12, 30), "Dividendo", "BBDC4", "BANCO BRADESCO S/A", "NOVA FUTURA CTVM LTDA", 60, 0.20, 12.00),
                                                   new StockMovement("Credito", new DateTime(2021, 12, 30), "Juros Sobre Capital Próprio", "BBDC4", "BANCO BRADESCO S/A", "NOVA FUTURA CTVM LTDA", 56, 0.02, 1.03),
                                                   new StockMovement("Credito", new DateTime(2021, 12, 15), "Dividendo", "CRFB3", "ATACADAO S/A", "NOVA FUTURA CTVM LTDA", 50, 0.12, 6.00),
                                                   new StockMovement("Debito", new DateTime(2021, 12, 08), "Transferência - Liquidação", "ABEV3", "AMBEV S/A", "NOVA FUTURA CTVM LTDA", 54, 16.12, 870.48),
                                                   new StockMovement("Credito", new DateTime(2021, 06, 10), "Dividendo", "CRFB3", "ATACADAO S/A", "NOVA FUTURA CTVM LTDA", 50, 0.12, 6.00),
                                                   new StockMovement("Credito", new DateTime(2021, 06, 30), "Dividendo", "BBDC4", "BANCO BRADESCO S/A", "NOVA FUTURA CTVM LTDA", 60, 0.20, 12.00));
        }

        [Test]
        public void Return_Dividend_Total()
        {
            var calculator = new DividendCalculator(_StockMoviments);
            Assert.That(calculator.TotalDividends(), Is.EqualTo(36.00));
        }

        [Test]
        public void Return_Dividend_Total_By_Stock()
        {
            var calculator = new DividendCalculator(_StockMoviments);
            Assert.That(calculator.TotalDividends("BBDC4"), Is.EqualTo(24.00));
        }

        [Test]
        public void Dont_Calculate_Dividend_If_Direction_Different_Than_Credito()
        {
            var calculator = new DividendCalculator(ImmutableList.Create(
                new StockMovement("Credito", new DateTime(2021, 12, 30), "Dividendo", "BBDC4", "BANCO BRADESCO S/A", "NOVA FUTURA CTVM LTDA", 60, 0.20, 12.00),
                new StockMovement("Debito", new DateTime(2021, 06, 30), "Dividendo", "BBDC4", "BANCO BRADESCO S/A", "NOVA FUTURA CTVM LTDA", 60, 0.40, 24.00)));

            Assert.That(calculator.TotalDividends("BBDC4"), Is.EqualTo(12.00));
        }
    }
}