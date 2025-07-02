namespace OrderingDomain.ValueObjects;

public record Payment
{
    #region Properties
    public string? CardName { get; } = string.Empty;
    public string CardNumber { get; } = string.Empty;
    public string Expiration { get;} = string.Empty;
    public string Cvv { get; } = string.Empty;
    public int PaymentMethod { get; init; } = default;
    #endregion

    #region Constructors
    protected Payment() 
    {
    }   
    private Payment(string? cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        Cvv = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string? cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrEmpty(cardNumber);
        ArgumentException.ThrowIfNullOrEmpty(expiration);
        ArgumentException.ThrowIfNullOrEmpty(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
    #endregion
}
