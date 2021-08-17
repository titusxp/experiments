using Alerts.Domain.Contracts.Dama;
using Alerts.Models.Common;
using Alerts.Models.Dama;
using Alerts.Repository.Contracts.Dama;
using Core.System.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Domain.Dama
{
    public class ARTVisitDomain : IARTVisitDomain
    {
        private readonly IARTVisitsRepository _Repository;
        private readonly ISMSClient _smsClient;

        public ARTVisitDomain(IARTVisitsRepository repo, ISMSClient smsClient)
        {
            _Repository = repo;
            _smsClient = smsClient;
        }

        private Message CreateMessage(ARTVisitViewModel visit)
        {
            return new Message
            {
                to = new[] { visit.PhoneNumber },
                content = "Dear patient, you have an appointment on " + visit.NextAppointmentDate.ToString() + " at " + visit.Artsite
            };
        }

        public async Task<IEnumerable<ARTVisitViewModel>> GetARTVisits(int numberOfDaysBeforeAppointment)
        {
            var visits = await _Repository.GetARTVisits(numberOfDaysBeforeAppointment);
            return visits;
        }

        public async Task<bool> SendAppointmentReminders(int numberOfDaysBeforeAppointment)
        {
            bool response = false;
            List<string> addressList = new List<string>();
            var visits = await _Repository.GetARTVisits(numberOfDaysBeforeAppointment);
            visits.ForEach(visit =>
            {
                addressList.Add(visit.PhoneNumber);
            });
            Message message = new Message
            {
                to = addressList.ToArray(),
                content = "Dear patient, you have an appointment in our facility on " + DateTime.Now.AddDays(numberOfDaysBeforeAppointment).ToLongDateString() + ", please don't miss it"
            };
            response = _smsClient.sendMessage(message);
            return response;
        }

        public async Task<MessageResponse> SendIndividualAppointmentReminders(int numberOfDaysBeforeAppointment)
        {
            MessageResponse response = new MessageResponse();
            var visits = await _Repository.GetARTVisits(numberOfDaysBeforeAppointment);
            visits.ForEach(visit =>
            {
                if (_smsClient.sendMessage(CreateMessage(visit)))
                {
                    response.NumberOfMessagesSent++;
                }
                else
                {
                    response.MessagesNotSent.Add(CreateMessage(visit));
                }
            });
            return response;
        }
    }
}
