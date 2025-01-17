using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Create;

public record CreateExempleCommand(
    string FirstName,
    string LastName,
    EGender Gender,
    ENotificationType Notification,
    string Email,
    string Phone,
    List<string> Role
) : IRequest<ApiResult<CreateExempleResponse>>;

