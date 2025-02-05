using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;
using API.Exemple.Core._08.Infrastructure.Integration;
using Polly;
using System.Net;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Service;

public class NotificationService : INotificationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NotificationService> _logger;
    private readonly IConfiguration _configuration;
    private readonly AsyncPolicy<HttpResponseMessage> _retryPolicy;

    public NotificationService(HttpClient httpClient, ILogger<NotificationService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;

        // Configuração da política de tentativas de retry
        _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(
                retryCount: _configuration.GetValue<int>(ApiConsts.RETRYCOUNT),
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, retryCount, context) =>
                {
                    // Lógica a ser executada a cada tentativa de retry
                    _logger.LogWarning($"Tentativa {retryCount} de envio de celular...");
                }
            );
    }

    public async Task NotificationAsync(NotificationRequest request)
    {

        await _retryPolicy.ExecuteAsync(async () =>
        {
            request.Auth = new AuthNotification()
            {
                AccountSid = _configuration.GetValue<string>(ApiConsts.AccountSid),
                AuthToken = _configuration.GetValue<string>(ApiConsts.AuthToken),
                From = _configuration.GetValue<string>(ApiConsts.From)
            };

            var response = await _httpClient.PostAsJsonAsync(
                _configuration.GetValue<string>(ApiConsts.BaseUrl),
                request
            );

            response.EnsureSuccessStatusCode();

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Falha ao enviar sms ou whatsapp: {error}");
            }
            return response;
        });
    }
}
