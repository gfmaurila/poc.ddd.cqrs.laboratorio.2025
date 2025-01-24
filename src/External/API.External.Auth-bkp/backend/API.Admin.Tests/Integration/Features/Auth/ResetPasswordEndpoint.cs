using API.External.Auth.Tests.Integration.Utilities;

namespace API.External.Auth.Tests.Integration.Features.Auth;

public class AuthResetPasswordTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public AuthResetPasswordTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }
}
