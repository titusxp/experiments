using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Models.Common
{
    public class MessageConfig
    {
        public string content { get; set; }
        public int NumberOfDays { get; set; }
        public string MessageFrom { get; set; }
    }
}
