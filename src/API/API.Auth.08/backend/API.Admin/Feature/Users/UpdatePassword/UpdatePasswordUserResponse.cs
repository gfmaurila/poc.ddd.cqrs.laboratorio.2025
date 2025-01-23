using Common.Net8;

namespace API.Auth.Net08.Feature.Users.UpdatePassword;

public class UpdatePasswordUserResponse : BaseResponse
{
    public UpdatePasswordUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
