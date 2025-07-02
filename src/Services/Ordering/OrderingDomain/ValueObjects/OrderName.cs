namespace OrderingDomain.ValueObjects
{
    public record OrderName
    {
        #region Properties
        private const int DefaultLength = 5;
        public string Value { get; set; }
        #endregion
        #region Constructors
        private OrderName(string value)
        {
            Value = value;
        }
        #endregion

        #region Methods
        public static OrderName Of(string  value)
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength, "OrderName must be exactly 5 characters long.");

            return new OrderName(value);
        }
        #endregion
    }
}
