using Common.Core._08.Interface;

namespace API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;

public class RabbiMQInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();
        //services.AddScoped<ITwilioService, TwilioService>();

        // Publish
        //services.AddScoped<ITwilioProducer, TwilioProducer>();

        // Subscribe
        // services.AddHostedService<TwilioWhatsAppConsumer>();
    }
}
