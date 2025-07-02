namespace OrderingDomain.ValueObjects;

public record OrderItemId
{
    #region Properties
    public Guid Value { get; }
    #endregion

    #region Constructors
    private OrderItemId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Methods
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("OrderItemId cannot be empty.");
        }
        return new OrderItemId(value);
    }
    #endregion
}
