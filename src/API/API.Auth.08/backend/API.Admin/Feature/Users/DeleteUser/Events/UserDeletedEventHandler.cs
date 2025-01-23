using API.Auth.Net08.Domain.User.Events;
using API.Auth.Net08.Feature.Users.GetUser;
using API.Auth.Net08.Infrastructure.Database.Repositories.Interfaces;
using MediatR;

namespace API.Auth.Net08.Feature.Users.DeleteUser.Events;

public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
{
    private readonly ILogger<UserDeletedEventHandler> _logger;
    private readonly IUserRepository _repo;
    public UserDeletedEventHandler(ILogger<UserDeletedEventHandler> logger,
                                   IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
    }
}
