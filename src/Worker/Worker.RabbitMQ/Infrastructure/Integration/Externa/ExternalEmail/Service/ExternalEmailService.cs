using Polly;
using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Api;
using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Model;

namespace Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Service;


public class ExternalEmailService : IExternalEmailService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ExternalEmailService> _logger;
    private readonly IConfiguration _configuration;
    private readonly AsyncPolicy<HttpResponseMessage> _retryPolicy;
    private readonly IExternalEmailApi _api;

    public ExternalEmailService(HttpClient httpClient,
                                ILogger<ExternalEmailService> logger,
                                IExternalEmailApi api,
                                IConfiguration configuration)
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
                    _logger.LogWarning($"Tentativa {retryCount} acesso a api...");
                    //_api = api ?? throw new ArgumentNullException(nameof(api));
                }
            );

        _api = api ?? throw new ArgumentNullException(nameof(api));
    }

    public async Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var response = await _api.SendMessageAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning($"Erro na requisição: {response.StatusCode}, Mensagem: {response.Error.Content}");
            throw new Exception($"Erro na requisição: {response.StatusCode}, Mensagem: {response.Error.Content}");
        }
        return response.Content;
    }

    public async Task<List<ListSendResponse>> GetListSendAsync()
    {
        var response = await _api.GetListSendAsync();
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning($"Erro na requisição GET: {response.StatusCode}, Mensagem: {response.Error.Content}");
            throw new Exception($"Erro na requisição GET: {response.StatusCode}, Mensagem: {response.Error.Content}");
        }
        return response.Content;
    }
}