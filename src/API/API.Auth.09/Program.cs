using API.Auth.Extensions;

namespace API.Auth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddNewtonsoftJson();

        builder.Services.AddControllers();
        builder.Services.AddConnections();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfig(builder.Configuration);
        builder.Services.UseAuthentication(builder.Configuration);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
