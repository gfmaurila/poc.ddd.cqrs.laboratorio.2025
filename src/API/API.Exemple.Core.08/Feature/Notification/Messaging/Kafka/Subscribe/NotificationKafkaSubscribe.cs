using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Request;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Service;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Subscribe;

public class NotificationKafkaSubscribe : IHostedService
{
    private readonly ILogger<NotificationKafkaSubscribe> _logger;
    private readonly IConsumer<Null, string> _consumer;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;

    public NotificationKafkaSubscribe(IConfiguration configuration, ILogger<NotificationKafkaSubscribe> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
        _configuration = configuration;

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = _configuration.GetValue<string>("Kafka:BootstrapServers"),
            GroupId = "notification-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Kafka Consumer...");
        _consumer.Subscribe(NotificationEventConstants.EventNotificationCreate);

        Task.Run(() => ConsumeMessages(cancellationToken), cancellationToken);

        return Task.CompletedTask;
    }

    private async Task ConsumeMessages(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(cancellationToken);

                if (consumeResult != null)
                {
                    _logger.LogInformation($"Received message: {consumeResult.Message.Value}");

                    try
                    {
                        var notificationEvent = JsonConvert.DeserializeObject<NotificationEvent>(consumeResult.Message.Value);

                        if (notificationEvent != null)
                        {
                            // Cria um escopo para resolver o serviço com escopo
                            using (var scope = _scopeFactory.CreateScope())
                            {
                                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                                var request = new NotificationRequest
                                {
                                    To = notificationEvent.To,
                                    Body = notificationEvent.Body,
                                    Notification = notificationEvent.NotificationType,
                                    Auth = new AuthNotification()
                                    {
                                        AccountSid = _configuration.GetValue<string>(ExternalEmailApiConsts.AccountSid),
                                        AuthToken = _configuration.GetValue<string>(ExternalEmailApiConsts.AuthToken),
                                        From = _configuration.GetValue<string>(ExternalEmailApiConsts.From),
                                    }
                                };

                                await notificationService.NotificationAsync(request);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error processing message: {ex.Message}");
                    }

                    _consumer.Commit(consumeResult);
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Kafka Consumer stopped.");
        }
        finally
        {
            _consumer.Close();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Kafka Consumer...");
        _consumer.Close();
        return Task.CompletedTask;
    }
}


