﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Worker.RabbitMQ.Infrastructure.Messaging.API.Exemple.Core._08.Model;

namespace Worker.RabbitMQ.Infrastructure.Messaging.API.Exemple.Core._08;

public class CreateExempleConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IConfiguration _configuration;
    private readonly IModel _channel;
    private readonly ILogger<CreateExempleConsumer> _logger;

    public CreateExempleConsumer(IServiceProvider servicesProvider, IConfiguration configuration, ILogger<CreateExempleConsumer> logger)
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
            queue: ExempleEventConstants.QueueExempleCreate,
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
                _logger.LogInformation("CreateExempleConsumer running at: {time}", DateTimeOffset.Now);
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
            _channel.BasicConsume(ExempleEventConstants.QueueExempleCreate, false, consumer);
            await Task.Delay(1000, stoppingToken);
        }
    }

    //protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //{
    //    var consumer = new EventingBasicConsumer(_channel);
    //    consumer.Received += async (sender, eventArgs) =>
    //    {
    //        var infoBytes = eventArgs.Body.ToArray();
    //        var infoJson = Encoding.UTF8.GetString(infoBytes);
    //        var info = JsonSerializer.Deserialize<ExempleConsumer>(infoJson);
    //        await SendNotification(info);
    //        _channel.BasicAck(eventArgs.DeliveryTag, false);
    //    };
    //    _channel.BasicConsume(ExempleEventConstants.QueueExempleCreate, false, consumer);
    //    return Task.CompletedTask;
    //}

    public async Task SendNotification(ExempleConsumer dto)
    {
        // Faz algo
    }
}
