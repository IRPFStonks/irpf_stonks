using Ardalis.SmartEnum;

namespace IRPFStonks.BusinessLogic.Model.Movement
{
    /// <summary>
    /// These are the direction of a stock moviment.
    /// </summary>
    public sealed class MovementDirection : SmartEnum<MovementDirection>
    {
        private MovementDirection(string description, int value) : base(description, value)
        {
        }

        public static readonly MovementDirection Credit = new("Credito", 1);
        public static readonly MovementDirection Debit = new("Debito", 2);
    }
}
