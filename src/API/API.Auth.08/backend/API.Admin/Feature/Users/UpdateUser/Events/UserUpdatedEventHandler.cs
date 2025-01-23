using API.Auth.Net08.Domain.User.Events;
using API.Auth.Net08.Feature.Users.GetUser;
using API.Auth.Net08.Infrastructure.Database.Repositories.Interfaces;
using MediatR;

namespace API.Auth.Net08.Feature.Users.UpdateUser.Events;

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
