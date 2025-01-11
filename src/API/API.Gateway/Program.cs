
using API.Gateway.Extensions;

namespace API.Gateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        //builder.Services.AddOpenApi();

        builder.Services.AddConnections();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfig(builder.Configuration);

        builder.Services.AddReverseProxy()
                        .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        //app.MapControllers();

        app.MapReverseProxy();

        app.Run();
    }
}