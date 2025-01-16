namespace Common.Core.Domain.Interface;

public interface IAuditableEntity
{
    public DateTimeOffset CreatedAtUtc { get; }
    public DateTimeOffset LastModifiedAtUtc { get; }

}