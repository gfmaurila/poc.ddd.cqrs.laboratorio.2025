using Common.Core._08.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Interface;

public interface INotificationHandle
{
    bool IsNotification();
    List<Notification> GetNotification();
    void Handle(Notification notification);
}
