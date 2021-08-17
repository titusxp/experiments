using Alerts.Models.Personel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Models.Common
{
    public class TokenResponse
    {
        public string token { get; set; }
    }

    public class MessageBase
    {   
        public string content { get; set; }
    }

    public class Message : MessageBase
    {
        public string[] to { get; set; }
    }

    public class SMSObject
    {
        public string from { get; set; }
        public string[] to { get; set; }
        public string type { get; set; }
        public string content { get; set; }
    }
}
