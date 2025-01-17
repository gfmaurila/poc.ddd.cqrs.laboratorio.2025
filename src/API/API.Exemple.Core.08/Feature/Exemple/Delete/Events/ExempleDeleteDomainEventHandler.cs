using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Get;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Delete.Events;

public class ExempleDeleteDomainEventHandler : INotificationHandler<ExempleDeleteDomainEvent>
{
    private readonly ILogger<ExempleDeleteDomainEventHandler> _logger;
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<List<ExempleQueryModel>> _cacheService;
    public ExempleDeleteDomainEventHandler(ILogger<ExempleDeleteDomainEventHandler> logger,
                                   IExempleRepository repo,
                                   IRedisCacheService<List<ExempleQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(ExempleDeleteDomainEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetExempleQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));
    }
}
