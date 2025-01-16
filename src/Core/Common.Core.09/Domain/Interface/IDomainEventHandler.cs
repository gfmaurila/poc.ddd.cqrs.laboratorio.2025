using MediatR;

namespace Common.Core.Domain.Interface;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{ }
