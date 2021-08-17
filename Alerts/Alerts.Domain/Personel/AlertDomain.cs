using Alerts.Domain.Contracts.Personnel;
using Alerts.Models.Common;
using Alerts.Models.Personel;
using Alerts.Repository.Contracts.Personel;
using Core.System.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Domain.Personel
{
    public class AlertDomain : IAlertDomain
    {
        private readonly IAlertRepository _repo;
        private readonly ISMSClient _smsClient;

        public AlertDomain(IAlertRepository repo, ISMSClient smsClient)
        {
            _repo = repo;
            _smsClient = smsClient;
        }

        private Message CreateMessage(Alert alert)
        {
            return new Message
            {
                content = alert.Bodysms,
                to = new[] { alert.Telephone },
            };
        }

       
        public async Task<List<Alert>> GetAlerts()
        {
            var alerts = await _repo.GetAlerts();
            return alerts;
        }

        public async Task<MessageResponse> SendMonthlyAlerts()
        {
            MessageResponse response = new MessageResponse();
            var alerts = await _repo.GetAlerts();
            alerts.ForEach(alert =>
            {
                if(_smsClient.sendMessage(CreateMessage(alert)))
                {
                    response.NumberOfMessagesSent++;
                }
                else
                {
                    response.MessagesNotSent.Add(CreateMessage(alert));
                }
            });
            return response;
        }
    }
}
