using Common.Core._08.Domain.Errors;

namespace Common.Core._08.Domain.Interface;

public interface IDomainError
{
    string? ErrorMessage { get; init; }
    ErrorType ErrorType { get; init; }
    public List<string>? Errors { get; init; }
}
