using Common.Net8;

namespace API.Auth.Net08.Feature.Users.DeleteUser;

public class DeleteUserResponse : BaseResponse
{
    public DeleteUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
