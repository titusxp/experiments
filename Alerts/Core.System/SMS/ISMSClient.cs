using Alerts.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.System.SMS
{
    public interface ISMSClient
    {
        bool sendMessage();
        bool sendMessage(Message message);
    }
}
