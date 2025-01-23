using API.Auth.Net08.Domain;
using Common.Net8.Enumerado;

namespace API.Auth.Net08.Feature.Users.GetUser;

public class UserQueryModel : BaseQueryModel
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public DateTime DateOfBirth { get; init; }

    public string Email { get; init; }
    public string Phone { get; init; }
}
