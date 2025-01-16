using Common.Core.Domain.Errors;

namespace Common.Core.Domain.Interface;

public interface IDomainError
{
    string? ErrorMessage { get; init; }
    ErrorType ErrorType { get; init; }
    public List<string>? Errors { get; init; }
}
