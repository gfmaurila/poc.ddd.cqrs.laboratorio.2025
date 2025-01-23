using API.Auth.Net08.Domain.User.Events;
using API.Auth.Net08.Feature.Users.GetUser;
using API.Auth.Net08.Infrastructure.Database.Repositories.Interfaces;
using MediatR;

namespace API.Auth.Net08.Feature.Users.CreateUser.Events;


public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;
    private readonly IUserRepository _repo;
    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger,
                                   IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
    }
}