using Common.Net8.Response;
using MediatR;

namespace API.Auth.Net08.Feature.Users.GetUser;

public class GetUserQuery : IRequest<ApiResult<List<UserQueryModel>>>
{
    public GetUserQuery()
    {
    }
}
