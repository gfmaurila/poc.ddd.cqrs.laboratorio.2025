using Refit;
using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Model;

namespace Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Api;

public interface IExternalEmailApi
{
    [Post("/api/createsend")]
    Task<ApiResponse<CreateSendResponse>> SendMessageAsync([Body] CreateSendRequest request);

    [Get("/api/listsend")]
    Task<ApiResponse<List<ListSendResponse>>> GetListSendAsync();
}
