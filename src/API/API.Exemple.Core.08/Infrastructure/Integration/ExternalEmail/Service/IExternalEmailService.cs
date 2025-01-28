using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;

namespace API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;

public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
}
