namespace OrderingDomain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    #region Properties
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    #endregion
}