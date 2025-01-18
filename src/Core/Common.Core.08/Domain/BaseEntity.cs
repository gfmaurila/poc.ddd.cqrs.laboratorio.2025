using Common.Core._08.Domain.Events;
using Common.Core._08.Domain.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Common.Core._08.Domain;

/// <summary>
/// Base class that contains the behaviors of an entity.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class BaseEntity : IEntity<Guid>
{
    private readonly List<Event> _domainEvents = new();

    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// Defaults to a newly generated <see cref="Guid"/>.
    /// </summary>
    public Guid Id { get; protected set; } = Guid.NewGuid();

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    /// <param name="id">The new identifier for the entity.</param>
    public virtual void SetId(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the list of domain events that have occurred.
    /// </summary>
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to the entity.
    /// </summary>
    /// <param name="domainEvent">The domain event to add.</param>
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all domain events from the entity.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}

