public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId> 
{
    #region Properties
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    #endregion

    #region Methods
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();
        
         _domainEvents.Clear();

        return dequeuedEvents;
    }
    #endregion
}
