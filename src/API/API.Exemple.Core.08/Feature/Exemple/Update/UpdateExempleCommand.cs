using API.Exemple.Core._08.Feature.Exemple.Create;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.Exemple.Core._08.Feature.Exemple.Update;

public record UpdateExempleCommand(
    Guid Id,
    string FirstName,
    string LastName,
    EGender Gender,
    ENotificationType Notification,
    string Email,
    string Phone,
    List<string> Role
) : IRequest<ApiResult<UpdateExempleResponse>>;


