using OrderingApplication.Data;
using System.Reflection;

namespace OrderingInfrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    #region Constructors
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    #endregion

    #region Properties
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    #endregion

    #region Methods
    protected override void OnModelCreating(ModelBuilder builder)
    {
        _ = builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    #endregion
}
