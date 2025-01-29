using API.Exemple.Core._08.Extensions;
using FluentValidation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Configura enum como string no JSON
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase; // CamelCase opcional
    });

builder.Services.AddControllers();
builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
//builder.Services.AddCarter();

// Swagger
builder.Services.AddSwaggerConfig(builder.Configuration);
builder.Services.UseAuthentication(builder.Configuration);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});


var app = builder.Build();


// Apply migrations at runtime
app.ApplyMigrations();

//app.MapCarter();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();

public partial class Program { }

