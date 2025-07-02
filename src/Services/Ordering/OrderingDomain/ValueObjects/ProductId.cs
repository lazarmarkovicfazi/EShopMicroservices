namespace OrderingDomain.ValueObjects;

public record ProductId
{
    #region Properties
    public Guid Value { get; }
    #endregion

    #region Constructors
    private ProductId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Methods
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("ProductId cannot be empty.");
        }
        return new ProductId(value);
    }
    #endregion
}
