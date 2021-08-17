using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Models.Common
{
    public class Configuration
    {
        public string id { get; set; }
        public string name { get; set; }
        public string messageSender { get; set; }
        public string countryCode { get; set; }
        public int numberOfResendAttempts { get; set; }
        public string messageType { get; set; }
        public bool shouldSendSMSAlert { get; set; }
        public bool shouldSendEmailAlert { get; set; }


        public bool isEventMessage { get; set; }
        public DateTime eventDate { get; set; }
        public string eventName { get; set; }
        public int numberOfDaysBeforeEvent { get; set; }
        public string messageToSend { get; set; }


        public string dataUrl { get; set; }
        public string columnMessageContent { get; set; }
        public string columnMessageReceiver { get; set; }
    }
}
