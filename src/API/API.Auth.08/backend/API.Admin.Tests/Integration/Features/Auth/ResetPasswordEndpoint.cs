using API.Auth.Net08.Tests.Integration.Utilities;

namespace API.Auth.Net08.Tests.Integration.Features.Auth;

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
