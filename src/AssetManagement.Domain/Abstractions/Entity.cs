namespace AssetManagement.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(int id)
    {
        Id = id;
    }



    public int Id { get; protected set; }

    protected Entity()
    {
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}