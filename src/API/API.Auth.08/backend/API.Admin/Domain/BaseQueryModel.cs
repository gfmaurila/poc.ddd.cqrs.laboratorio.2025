using Common.Net8.Abstractions;

namespace API.Auth.Net08.Domain;

public abstract class BaseQueryModel : IQueryModel<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
