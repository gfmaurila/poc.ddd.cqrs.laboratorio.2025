namespace Common.Core.Domain.Interface;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    IReadOnlyCollection<IDomainEvent> PopDomainEvents();
    void ClearEvents();
}
