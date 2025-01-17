using Common.Core._08.Domain.Interface;

namespace Common.Core._08.Domain.Model;

public abstract class BaseQueryModel : IQueryModel<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
