using API.External.Person.Infrastructure.Integration.ExternalEmail.Model;
using Refit;

namespace API.External.Person.Infrastructure.Integration.ExternalEmail.Api;

public interface IExternalEmailApi
{
    [Post("/api/createsend")]
    Task<ApiResponse<CreateSendResponse>> SendMessageAsync([Body] CreateSendRequest request);

    [Get("/api/listsend")]
    Task<ApiResponse<List<ListSendResponse>>> GetListSendAsync();
}


