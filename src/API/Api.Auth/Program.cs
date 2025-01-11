using API.Auth.Extensions;

namespace API.Auth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adicionando serviços
        builder.Services.AddControllers()
            .AddNewtonsoftJson(); // Forçar uso do Newtonsoft.Json

        builder.Services.AddControllers();
        builder.Services.AddConnections();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfig(builder.Configuration);
        builder.Services.UseAuthentication(builder.Configuration);

        var app = builder.Build();

        // Configuração de middlewares
        if (app.Environment.IsEnvironment("Test") ||
            app.Environment.IsDevelopment() ||
            app.Environment.IsEnvironment("Docker") ||
            app.Environment.IsStaging() ||
            app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
