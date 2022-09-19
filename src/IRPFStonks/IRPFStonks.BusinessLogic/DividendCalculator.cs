using IRPFStonks.BusinessLogic.Model.Movement;

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
            return movement.Type.Equals(MovementType.Dividend) && movement.Direction.Equals(MovementDirection.Credit);
        }

        private double SumStrategy(StockMovement movement)
        {
            return movement.TotalPrice;
        }

    }
}