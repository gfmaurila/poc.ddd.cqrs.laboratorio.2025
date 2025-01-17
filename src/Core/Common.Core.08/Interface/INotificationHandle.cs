using Common.Core._08.Model;

namespace Common.Core._08.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<Notification> GetNotification();
    void Handle(Notification notification);
}
