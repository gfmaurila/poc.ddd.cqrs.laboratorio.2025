using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace API.Auth.Net08.Tests.Integration.Utilities;

public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        //builder.UseEnvironment("Test");
    }
}
