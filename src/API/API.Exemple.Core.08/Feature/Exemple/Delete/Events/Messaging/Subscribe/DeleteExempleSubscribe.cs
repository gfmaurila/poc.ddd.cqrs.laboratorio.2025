using API.Exemple.Core._08.Feature.Domain.Common;
using API.Exemple1.Core._08.Infrastructure.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.Exemple1.Core._08.Feature.Exemple.Delete.Events.Messaging.Subscribe;

public class DeleteExempleSubscribe : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IConfiguration _configuration;
    private readonly IModel _channel;

    public DeleteExempleSubscribe(IServiceProvider servicesProvider, IConfiguration configuration)
    {
        _configuration = configuration;

        var factory = new ConnectionFactory
        {
            HostName = _configuration.GetValue<string>(MessagingConsts.Hostname),
            Port = Convert.ToInt32(_configuration.GetValue<string>(MessagingConsts.Port)),
            UserName = _configuration.GetValue<string>(MessagingConsts.Username),
            Password = _configuration.GetValue<string>(MessagingConsts.Password)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: ExempleEventConstants.EventExempleDelete,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (sender, eventArgs) =>
        {
            var infoBytes = eventArgs.Body.ToArray();
            var infoJson = Encoding.UTF8.GetString(infoBytes);
            var info = JsonSerializer.Deserialize<ExempleConsumer>(infoJson);
            await SendNotification(info);
            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };
        _channel.BasicConsume(ExempleEventConstants.EventExempleDelete, false, consumer);
        return Task.CompletedTask;
    }

    public async Task SendNotification(ExempleConsumer dto)
    {
        // Faz algo
    }
}
