using IRPFStonks.BusinessLogic.Model;

namespace IRPFStonks.BusinessLogic
{
    /// <summary>
    /// Calculator for Dividends.
    /// </summary>
    public class DividendCalculator
    {
        private readonly IEnumerable<StockMovement> _stockMovements;

        public DividendCalculator(IEnumerable<StockMovement> stockMovements)
        {
            _stockMovements = stockMovements;
        }

        internal double TotalDividends()
        {
           return _stockMovements.Where(SelectDividends).Sum(SumStrategy);
        }

        internal double TotalDividends(string strockCode)
        {
           return _stockMovements.Where(x => SelectDividends(x) && x.StockCode.Equals(strockCode, StringComparison.InvariantCultureIgnoreCase)).Sum(SumStrategy);
        }

        private bool SelectDividends(StockMovement movement)
        {
            return movement.Type.Equals("Dividendo", StringComparison.InvariantCultureIgnoreCase) && movement.Direction.Equals("Credito", StringComparison.InvariantCultureIgnoreCase);
        }

        private double SumStrategy(StockMovement movement)
        {
            return movement.TotalPrice;
        }

    }
}