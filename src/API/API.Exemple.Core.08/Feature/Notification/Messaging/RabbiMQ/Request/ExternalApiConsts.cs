namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;

public class ExternalApiConsts
{
    public const string BaseUrl = "ExternalApi:BaseUrl";

    public const string AccountSid = "ExternalApi:Auth:AccountSid";
    public const string AuthToken = "ExternalApi:Auth:AuthToken";
    public const string From = "ExternalApi:Auth:From";

    public const string TIMEOUT = "ExternalApi:TIMEOUT";
    public const string RETRYCOUNT = "ExternalApi:RetryPolicy:RetryCount";
    public const string SleepDurationProvider = "ExternalApi:RetryPolicy:SleepDurationProvider";
}
