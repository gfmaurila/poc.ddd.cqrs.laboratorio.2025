using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail;
using Worker.RabbitMQ.Infrastructure.Messaging;

namespace Worker.RabbitMQ;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Registre o serviço com sua interface
        ExternalEmailInitializer.Initialize(builder.Services, builder.Configuration);

        RabbiMQInitializer.Initialize(builder.Services);
        //builder.Services.AddHostedService<NotificationConsumer>();
        //builder.Services.AddHostedService<Worker>();

        var host = builder.Build();

        host.Run();
    }
}