using API.External.Auth.Domain.User.Events;
using API.External.Auth.Feature.Users.GetUser;
using API.External.Auth.Infrastructure.Database.Repositories.Interfaces;
using MediatR;

namespace API.External.Auth.Feature.Users.UpdateUser.Events;

public class UserUpdatedEventHandler : INotificationHandler<UserUpdatedEvent>
{
    private readonly ILogger<UserUpdatedEventHandler> _logger;
    private readonly IUserRepository _repo;
    public UserUpdatedEventHandler(ILogger<UserUpdatedEventHandler> logger,
                                   IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
    }
}
