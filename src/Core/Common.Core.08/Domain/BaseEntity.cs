using Common.Core._08.Domain.Events;
using Common.Core._08.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Domain;

/// <summary>
/// Classe base que contém os comportamentos de uma entidade.
/// </summary>
/// 
[ExcludeFromCodeCoverage]
public abstract class BaseEntity : IEntity<Guid>
{
    private readonly List<Event> _domainEvents = new();

    public Guid Id { get; protected set; } = Guid.NewGuid();

    public virtual void SetId(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Eventos de domínio que ocorreram.
    /// </summary>
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adicionar evento de domínio.
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Limpa os eventos de domínio.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}
