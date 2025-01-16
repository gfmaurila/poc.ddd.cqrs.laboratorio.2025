namespace Common.Core.Domain.Interface;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow();
}
