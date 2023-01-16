namespace IRPFStonks.BusinessLogic.Model.Movement
{
    /// <summary>
    /// Class that represents an line from the Movimentação spread sheet from Brazilian Stock Exchange Agency
    /// </summary>
    public sealed class StockMovement : IEquatable<StockMovement?>
    {

        public StockMovement(MovementDirection direction,
                             DateTime date,
                             MovementType type,
                             string stockCode,
                             string stockCompany,
                             string institution,
                             double quantity,
                             double unityPrice,
                             double totalPrice)
        {
            Direction = direction;
            Date = date;
            Type = type;
            StockCode = stockCode;
            StockCompany = stockCompany;
            Institution = institution;
            Quantity = quantity;
            UnityPrice = unityPrice;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// Gets Direction of the movement, Credit or Debit
        /// </summary>
        public MovementDirection Direction { get; set; }
        /// <summary>
        /// Gets the date if the moviment
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets the Type of the moviment
        /// </summary>
        public MovementType Type { get; set; }
        /// <summary>
        /// Gets the Stock Code
        /// </summary>
        public string StockCode { get; set; }
        /// <summary>
        /// Gets the Stock Company Name
        /// </summary>
        public string StockCompany { get; set; }
        /// <summary>
        /// Get the Institution that handle the moviment with the B3 Stock Exchange
        /// </summary>
        public string Institution { get; set; }
        /// <summary>
        /// Gets the Quantity of stocks for the movement
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// Gets the unity price paid per stock
        /// </summary>
        public double UnityPrice { get; set; }
        /// <summary>
        /// Gets total price paid by all the stock in the movement
        /// </summary>
        public double TotalPrice { get; set; }

        public static StockMovement Empty => new(MovementDirection.Credit, DateTime.UtcNow, MovementType.Dividend, "IRPF01", "IRPFStonks", "Stonks Agency", 0, 0, 0);

        public override bool Equals(object? obj)
        {
            return Equals(obj as StockMovement);
        }

        public bool Equals(StockMovement? other)
        {
            return other is not null &&
                   Direction == other.Direction &&
                   Date == other.Date &&
                   Type == other.Type &&
                   StockCode == other.StockCode &&
                   StockCompany == other.StockCompany &&
                   Institution == other.Institution &&
                   Quantity == other.Quantity &&
                   UnityPrice == other.UnityPrice &&
                   TotalPrice == other.TotalPrice;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Direction);
            hash.Add(Date);
            hash.Add(Type);
            hash.Add(StockCode);
            hash.Add(StockCompany);
            hash.Add(Institution);
            hash.Add(Quantity);
            hash.Add(UnityPrice);
            hash.Add(TotalPrice);
            return hash.ToHashCode();
        }

        public static bool operator ==(StockMovement? left, StockMovement? right)
        {
            return EqualityComparer<StockMovement>.Default.Equals(left, right);
        }

        public static bool operator !=(StockMovement? left, StockMovement? right)
        {
            return !(left == right);
        }
    }
}