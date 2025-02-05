using FluentValidation;

namespace API.Exemple.Core._08.Feature.Exemple.GetById;

public class GetExempleByIdQueryValidator : AbstractValidator<GetExempleByIdQuery>
{
    public GetExempleByIdQueryValidator()
        => RuleFor(command => command.Id).NotEmpty();
}

