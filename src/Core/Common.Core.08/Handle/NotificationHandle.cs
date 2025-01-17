using Common.Core._08.Interface;
using Common.Core._08.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Handle;

public class NotificationHandle : INotificationHandle
{
    private List<Notification> _notification;

    public NotificationHandle()
    {
        _notification = new List<Notification>();
    }

    public void Handle(Notification notification)
    {
        _notification.Add(notification);
    }

    public List<Notification> GetNotification()
    {
        return _notification;
    }

    public bool IsNotification()
    {
        return _notification.Any();
    }
}
