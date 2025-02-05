using API.HR.Core.Feature.External.ExternalEmail.Get;
using API.HR.Core.Feature.External.ExternalEmail.Get.Model;
using API.HR.Core.Infrastructure.Integration.ExternalEmail.Model;

namespace API.HR.Core.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
