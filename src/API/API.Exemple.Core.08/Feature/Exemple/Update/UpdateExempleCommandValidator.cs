using API.Exemple.Core._08.Feature.Exemple.Create;
using Common.Core._08.Domain.Enumerado;
using FluentValidation;

namespace API.Exemple.Core._08.Feature.Exemple.Update;

public class UpdateExempleCommandValidator : AbstractValidator<UpdateExempleCommand>
{
    public UpdateExempleCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.Email)
            .NotEmpty()
            .MaximumLength(254)
            .EmailAddress();

        // Validação para Gender, garantindo que um valor válido foi selecionado
        RuleFor(command => command.Gender)
            .Must(gender => gender != EGender.None)
            .WithMessage("Selecione um gênero válido. 'Não informar' não é uma opção permitida.");

        RuleFor(command => command.Role)
            .Must(roleList => roleList != null && roleList.Any())
            .WithMessage("É obrigatório fornecer pelo menos uma permissão.");

    }
}

