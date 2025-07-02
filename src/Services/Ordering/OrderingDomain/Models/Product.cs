namespace OrderingDomain.Models;

public class Product : Entity<ProductId>
{
    #region Properties
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
    #endregion

    #region Constructors
    #endregion

    #region Methods
    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
       
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfLessThan(price, 0);
        
        return new Product
        {
            Id = id,
            Name = name,
            Price = price
        };

    }
    #endregion

}
