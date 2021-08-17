using Alerts.Models.Common;
using Alerts.Models.Dama;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Repository.Contracts.Dama
{
    public interface IARTVisitsRepository
    {
        Task<List<ARTVisitViewModel>> GetARTVisits(int numberOfDaysBeforeAppointment);
        Task<ServiceResponse> UpdateVisit(ARTVisit visit);
    }
}
