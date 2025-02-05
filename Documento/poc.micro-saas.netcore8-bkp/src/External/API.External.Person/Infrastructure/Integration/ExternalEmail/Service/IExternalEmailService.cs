using API.External.Person.Feature.External.ExternalEmail.Get;
using API.External.Person.Feature.External.ExternalEmail.Get.Model;
using API.External.Person.Infrastructure.Integration.ExternalEmail.Model;

namespace API.External.Person.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
