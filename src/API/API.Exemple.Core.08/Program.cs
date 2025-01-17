
using API.Exemple.Core._08.Extensions;
using Serilog;
using System.Reflection;

namespace API.Exemple.Core._08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddConnections();
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            // Swagger
            builder.Services.AddSwaggerConfig(builder.Configuration);
            builder.Services.UseAuthentication(builder.Configuration);

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(builder.Configuration);
            });

            // Register MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
