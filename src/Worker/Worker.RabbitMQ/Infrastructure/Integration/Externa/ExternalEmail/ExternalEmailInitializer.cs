using Refit;
using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Api;
using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Service;

namespace Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail;

public class ExternalEmailInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration conf)
    {
        services.AddRefitClient<IExternalEmailApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(conf.GetValue<string>(ExternalEmailApiConsts.BaseUrl)));
        services.AddScoped<IExternalEmailService, ExternalEmailService>();
    }
}
