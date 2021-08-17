using Alerts.Models.Common;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.System.SMS
{
    public class SMSClient : ISMSClient
    {
        public string username { get; set; }
        public string password { get; set; }
        public SMSClient()
        {
            username = "AymeEL365";
            password = "Admin@123";

        }

        public string[] processReceiverAddresses(string[] receiverAddresses)
        {
            for (int i = 0; i < receiverAddresses.Length; i++)
            {
                receiverAddresses[i] = processReceiverAddress(receiverAddresses[i]);
            }
            return receiverAddresses;
        }

        public string processReceiverAddress(string receiverAddress)
        {   
            if (receiverAddress.Length == 14 && receiverAddress.StartsWith("00237")) return receiverAddress;
            return "00237" + receiverAddress.Trim().Substring(receiverAddress.Length - 9);
        }

        public bool sendMessage()
        {
            Message m = new Message();
            m.to = new[] { "00237651706600" };
            m.content = "Demo message from Dama SMS API";
            return sendMessage(m);
        }
       
        public bool sendMessage(Message message)
        {   
            message.to = GetValidReceivers(message.to);
            if(message.to.Length == 0) return false;
            if (!validMessage(message.content)) return false;
            var sms = JsonConvert.SerializeObject(new SMSObject
            {
                from = "Dama",
                to = processReceiverAddresses(message.to),
                type = "text",
                content = message.content
            });
            string token = getToken();

            var client = new RestClient("https://restapi.bulksmsonline.com/rest/api/v1/sms/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token", token);
            
            request.AddParameter(
                "application/json",
                sms,
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response.IsSuccessful;
        }


        #region Helpers
        private string getToken()
        {
            var client = new RestClient("https://restapi.bulksmsonline.com/rest/api/v1/sms/gettoken/username/" + username + "/password/" + password);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                client = new RestClient("https://restapi.bulksmsonline.com/rest/api/v1/sms/gettoken/username/" + username + "/password/" + password);
                request = new RestRequest(Method.GET);
                response = client.Execute(request);
            }
            return JsonConvert.DeserializeObject<TokenResponse>(response.Content).token;
        }

        private bool validMessage(string message)
        {
            return message.Length < 160;
        }

        private string[] GetValidReceivers(string[] phoneNumbers)
        {
            string[] validNumbers = { };
            for(int i=0;i<phoneNumbers.Length; i++)
            {
                if (validMessageReceiver(phoneNumbers[i]))
                {
                    validNumbers[validNumbers.Length] = phoneNumbers[i];
                }
            }
            return validNumbers;
        }

        
        private bool validMessageReceiver(string phoneNumber)
        {
            if (phoneNumber.Length > 14 || phoneNumber.Length < 9)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
