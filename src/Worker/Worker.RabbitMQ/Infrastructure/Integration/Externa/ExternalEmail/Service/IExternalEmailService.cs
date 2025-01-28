using Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Model;

namespace Worker.RabbitMQ.Infrastructure.Integration.Externa.ExternalEmail.Service;
public interface IExternalEmailService
{
    Task<CreateSendResponse> SendMessageAsync(CreateSendRequest request);
    Task<List<ListSendResponse>> GetListSendAsync();
}
