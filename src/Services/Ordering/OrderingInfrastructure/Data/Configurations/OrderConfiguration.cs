namespace OrderingInfrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasConversion(orderId => orderId.Value,
                           dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .IsRequired();

        builder.ComplexProperty(o => o.OrderName, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                .HasAnnotation("ColumnName", nameof(Order.OrderName))
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.EmailAddress)
                .HasMaxLength(100);

            addressBuilder.Property(a => a.AddressLine)
                .HasMaxLength(180)
                .IsRequired();

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.State)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(5);
        });

        builder.ComplexProperty(o => o.BillingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.EmailAddress)
                .HasMaxLength(100);

            addressBuilder.Property(a => a.AddressLine)
                .HasMaxLength(180)
                .IsRequired();

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.State)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(5);
        });

        builder.ComplexProperty(o => o.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(p => p.CardName)
                .HasMaxLength(50)
                .IsRequired();

            paymentBuilder.Property(p => p.CardNumber)
                .HasMaxLength(24)
                .IsRequired();

            paymentBuilder.Property(p => p.Expiration)
                .HasMaxLength(10);

            paymentBuilder.Property(p => p.Cvv)
                .HasMaxLength(3)
                .IsRequired();

            paymentBuilder.Property(p => p.PaymentMethod);
        });

        builder.Property(o => o.Status)
            .HasConversion(
                status => status.ToString(),
                dbStatus => Enum.Parse<OrderStatus>(dbStatus))
            .IsRequired();

        builder.Property(o => o.TotalPrice);
    }
}
