namespace Common.Core._08.Interface;
public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
