using System;
using System.Collections.Generic;
using System.Text;

namespace Core.System.Email
{
    public interface IEmailClient
    {
        bool SendEmail(string recipient, string subject, string message);
    }
}
