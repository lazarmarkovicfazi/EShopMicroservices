namespace OrderingDomain.ValueObjects;

public record CustomerId
{

    #region Properties
    public Guid Value { get; }

    #endregion

    #region Constructors
    private CustomerId(Guid value)
    {
        Value = value;
    }
    #endregion

    #region Methods
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }
        return new CustomerId(value);
    }
    #endregion
}
