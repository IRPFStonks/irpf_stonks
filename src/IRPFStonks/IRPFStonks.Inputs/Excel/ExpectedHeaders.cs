using Ardalis.SmartEnum;

namespace IRPFStonks.Inputs.Excel
{
    /// <summary>
    /// Expected headers in the Brazilian Stock Exchange (B3) Movement spreadsheet.
    /// </summary>
    public sealed class ExpectedHeader : SmartEnum<ExpectedHeader>
    {
        public ExpectedHeader(string name, int columnIndex) : base(name, columnIndex)
        {
        }

        public static readonly ExpectedHeader MovementDirection = new("Entrada/Saída", 0);
        public static readonly ExpectedHeader Date = new("Data", 1);
        public static readonly ExpectedHeader MovementType = new("Movimentação", 2);
        public static readonly ExpectedHeader StockCode = new("Produto", 3);
        public static readonly ExpectedHeader Institution = new("Instituição", 4);
        public static readonly ExpectedHeader Quantity = new("Quantidade", 5);
        public static readonly ExpectedHeader UnitPrice = new("Preço Unitário", 6);
        public static readonly ExpectedHeader TotalPrice = new("Valor da Operação", 7);
    }
}
