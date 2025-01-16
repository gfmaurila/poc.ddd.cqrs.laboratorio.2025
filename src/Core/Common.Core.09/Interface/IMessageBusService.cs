namespace Common.Core.Interface;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
