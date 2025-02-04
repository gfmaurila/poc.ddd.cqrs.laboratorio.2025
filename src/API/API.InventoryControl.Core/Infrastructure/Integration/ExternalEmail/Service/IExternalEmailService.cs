using API.InventoryControl.Core.Feature.External.ExternalEmail.Get;
using API.InventoryControl.Core.Feature.External.ExternalEmail.Get.Model;
using API.InventoryControl.Core.Infrastructure.Integration.ExternalEmail.Model;

namespace API.InventoryControl.Core.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
    Task<List<EmailQueryModel>> GetPaginatedItemsAsync(GetPaginateEmailQuery query);
    Task<int> GetTotalCountAsync();
}
