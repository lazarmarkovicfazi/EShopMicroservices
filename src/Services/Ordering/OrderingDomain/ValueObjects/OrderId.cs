namespace OrderingDomain.ValueObjects;

public record OrderId
{
    #region Properties
    public Guid Value { get; }
    #endregion

    #region Constructors
    private OrderId(Guid value)
    {
        Value = value;
    }
    #endregion

    #region Methods
    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }
        return new OrderId(value);
    }
    #endregion
}
