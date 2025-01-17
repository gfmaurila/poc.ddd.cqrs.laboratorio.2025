using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Interface;
public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
