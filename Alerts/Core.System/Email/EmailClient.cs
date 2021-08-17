using System;
using System.Net;

namespace Core.System.Email
{
    public class EmailClient : IEmailClient
    {
        public static readonly string EMAIL_SENDER = "helpdeskdama@gmail.com"; //damahelp@gmail.com | helpdeskdama@gmail.com 
        public static readonly string EMAIL_CREDENTIALS = "DamaP@55w0rd"; //DamaP@55w0rd
        public static readonly string SMTP_CLIENT = "smtp.gmail.com"; //smtp.gmail.com as we are using outlook so we have provided smtp-mail.outlook.com   

        public static readonly int SSL_PORT_SMTP = 587;//587
        public static readonly int PORT_SMTP = 25; //8889
        public static readonly string EMAIL_BODY = "Welcome to Dama";
        private string senderAddress;
        private string clientAddress;
        private string netPassword;

        public EmailClient()
        {
            senderAddress = "dama@cbchs.cm";
            netPassword = "P@55w0rd";
            clientAddress = "mail.cbchs.cm";
        }
        public EmailClient(string sender, string Password, string client)
        {
            senderAddress = sender;
            netPassword = Password;
            clientAddress = client;
        }

        public bool SendEmail(string recipient, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
