using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Worker.RabbitMQ.Infrastructure.Messaging.API.Exemple.Core._08;
using Worker.RabbitMQ.Infrastructure.Messaging.API.Exemple.Core._08.Model;

namespace Worker.RabbitMQ.Infrastructure.Messaging.ExternalEmail;

public class UpdateExempleConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IConfiguration _configuration;
    private readonly IModel _channel;
    private readonly ILogger<UpdateExempleConsumer> _logger;

    public UpdateExempleConsumer(IServiceProvider servicesProvider, IConfiguration configuration, ILogger<UpdateExempleConsumer> logger)
    {
        _configuration = configuration;

        var factory = new ConnectionFactory
        {
            HostName = _configuration.GetValue<string>(RabbiMQConsts.Hostname),
            Port = Convert.ToInt32(_configuration.GetValue<string>(RabbiMQConsts.Port)),
            UserName = _configuration.GetValue<string>(RabbiMQConsts.Username),
            Password = _configuration.GetValue<string>(RabbiMQConsts.Password)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: ExempleEventConstants.QueueExempleUpdate,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("UpdateExempleConsumer running at: {time}", DateTimeOffset.Now);
            }

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, eventArgs) =>
            {
                var infoBytes = eventArgs.Body.ToArray();
                var infoJson = Encoding.UTF8.GetString(infoBytes);
                var info = JsonSerializer.Deserialize<ExempleConsumer>(infoJson);
                await SendNotification(info);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume(ExempleEventConstants.QueueExempleUpdate, false, consumer);
            //return Task.CompletedTask;
            await Task.Delay(1000, stoppingToken);
        }

        //var consumer = new EventingBasicConsumer(_channel);
        //consumer.Received += async (sender, eventArgs) =>
        //{
        //    var infoBytes = eventArgs.Body.ToArray();
        //    var infoJson = Encoding.UTF8.GetString(infoBytes);
        //    var info = JsonSerializer.Deserialize<ExempleConsumer>(infoJson);
        //    await SendNotification(info);
        //    _channel.BasicAck(eventArgs.DeliveryTag, false);
        //};
        //_channel.BasicConsume(ExempleEventConstants.QueueExempleUpdate, false, consumer);
        //return Task.CompletedTask;
    }

    public async Task SendNotification(ExempleConsumer dto)
    {
        // Faz algo
    }
}
