
using Ardalis.SmartEnum;

namespace IRPFStonks.BusinessLogic.Model.Movement
{
    /// <summary>
    /// These are the different types of moviments for each stock movement
    /// </summary>
    public class MovementType : SmartEnum<MovementType>
    {
        internal MovementType(string description, int value) : base(description, value)
        {
        }

        public static readonly MovementType Dividend = new("Dividendo", 1);
        public static readonly MovementType Jcp = new("Juros Sobre Capital Próprio", 2);
        public static readonly MovementType TransferSettlement = new("Transferência - Liquidação", 3);
        public static readonly MovementType FractionAuction = new("Leilão de Fração", 4);
        public static readonly MovementType StockSplit = new("Cisão ou Desdobro", 5);
        public static readonly MovementType AssetFraction = new("Fração em Ativos", 6);

    }
}
