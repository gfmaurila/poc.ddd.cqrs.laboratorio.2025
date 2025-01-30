using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;
using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;
using API.Exemple1.Core._08.Infrastructure.Messaging;
using Confluent.Kafka;
using System.Text.Json;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;

public class NotificationKafkaSubscribe : BackgroundService
{
    private readonly ConsumerConfig _config;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<NotificationKafkaSubscribe> _logger;
    private readonly IConfiguration _configuration;
    private readonly Dictionary<string, Func<string, Task>> _topicHandlers;

    public NotificationKafkaSubscribe(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, ILogger<NotificationKafkaSubscribe> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;

        _config = new ConsumerConfig
        {
            BootstrapServers = _configuration.GetValue<string>(MessagingConsts.HostnameKafka),
            GroupId = NotificationEventConstants.EventNotificationExemple,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        _topicHandlers = new Dictionary<string, Func<string, Task>>
        {
            {
                NotificationEventConstants.EventNotificationCreate, SendNotificationAsync
            }
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
        var topics = _topicHandlers.Keys;
        consumer.Subscribe(topics);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);

                    if (_topicHandlers.TryGetValue(consumeResult.Topic, out var handler))
                    {
                        await handler(consumeResult.Message.Value);
                    }
                    else
                    {
                        _logger.LogWarning($"Nenhum manipulador encontrado para o tópico: {consumeResult.Topic}");
                    }

                    consumer.Commit(consumeResult);
                }
                catch (ConsumeException e)
                {
                    _logger.LogError($"Erro ao consumir mensagem: {e.Error.Reason}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Execução cancelada.");
        }
        finally
        {
            consumer.Close();
        }
    }

    private async Task SendNotificationAsync(string message)
    {
        try
        {
            var dto = JsonSerializer.Deserialize<NotificationRequest>(message);
            if (dto == null)
            {
                _logger.LogWarning("Mensagem Kafka inválida.");
                return;
            }

            using var scope = _serviceScopeFactory.CreateScope();
            var sendService = scope.ServiceProvider.GetRequiredService<IExternalEmailService>();

            var request = new CreateSendRequest()
            {
                Auth = new ExternalEmailAuth()
                {
                    AccountSid = _configuration.GetValue<string>("ExternalEmailApi:AccountSid"),
                    AuthToken = _configuration.GetValue<string>("ExternalEmailApi:AuthToken"),
                    From = _configuration.GetValue<string>("ExternalEmailApi:From"),
                },
                Body = dto.Body,
                To = dto.To,
                Notification = 1
            };

            await sendService.SendMessageAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao processar notificação: {ex.Message}");
        }
    }
}


