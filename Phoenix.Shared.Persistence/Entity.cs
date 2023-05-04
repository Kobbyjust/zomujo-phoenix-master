using Phoenix.Shared.Persistence.Events;

namespace Phoenix.Shared.Persistence;

public abstract class Entity
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public Audit? Audit { get; set; }

    public Entity AuditAs(Audit audit)
    {
        Audit = audit;
        return this;
    }
    
    private List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent">Domain event.</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
            throw new BusinessRuleValidationException(rule);
    }
}

public class Audit
{
    private Audit()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        CreatedBy = "admin";
        UpdatedBy = "admin";
        Status = EntityStatus.Normal;
    }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string UpdatedBy { get; private set; }
    public EntityStatus Status { get; private set; }

    public static Audit Create() => new();

    public Audit WasCreatedBy(string name)
    {
        CreatedBy = name;
        return this;
    }
    
    public Audit WasUpdatedBy(string name)
    {
        UpdatedBy = name;
        return this;
    }

    public Audit Delete()
    {
        Status = EntityStatus.Deleted;
        return this;
    }
    
    public Audit Archive()
    {
        Status = EntityStatus.Archived;
        return this;
    }
}

public enum EntityStatus
{
    Normal = 1,
    Archived,
    Deleted
}