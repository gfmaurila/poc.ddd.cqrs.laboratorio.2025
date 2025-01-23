using Common.Net8;

namespace API.Auth.Net08.Feature.Users.UpdateUser;

public class UpdateUserResponse : BaseResponse
{
    public UpdateUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
