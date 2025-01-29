using FluentValidation;

namespace API.Exemple.Core._08.Feature.Exemple.Delete;

public class DeleteExempleCommandValidator : AbstractValidator<DeleteExempleCommand>
{
    public DeleteExempleCommandValidator()
        => RuleFor(command => command.Id).NotEmpty();
}
