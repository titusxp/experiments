using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Models.Common
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
        where T : class
    {
        public T Data { get; set; }
    }

    public class MessageResponse
    {
        public int NumberOfMessagesSent { get; set; }
        public List<Message> MessagesNotSent { get; set; }
    }

    public class DeleteModel
    {
        public string _id { get; set; }
        public string _rev { get; set; }
    }
}
