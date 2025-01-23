using API.External.Auth.Domain.User.Events;
using API.External.Auth.Feature.Users.GetUser;
using API.External.Auth.Infrastructure.Database.Repositories.Interfaces;
using MediatR;

namespace API.External.Auth.Feature.Users.DeleteUser.Events;

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
