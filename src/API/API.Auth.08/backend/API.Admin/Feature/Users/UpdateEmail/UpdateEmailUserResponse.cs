using Common.Net8;

namespace API.Auth.Net08.Feature.Users.UpdateEmail;

public class UpdateEmailUserResponse : BaseResponse
{
    public UpdateEmailUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
