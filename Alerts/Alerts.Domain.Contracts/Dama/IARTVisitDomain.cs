using Alerts.Models.Common;
using Alerts.Models.Dama;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Domain.Contracts.Dama
{
    public interface IARTVisitDomain
    {
        Task<IEnumerable<ARTVisitViewModel>> GetARTVisits(int numberOfDaysBeforeAppointment);

        Task<bool> SendAppointmentReminders(int numberOfDaysBeforeAppointment);

        Task<MessageResponse> SendIndividualAppointmentReminders(int numberOfDaysBeforeAppointment);
    }
}
