using Alerts.Models.Common;
using Alerts.Models.Dama;
using Alerts.Repository.Contracts.Dama;
using Alerts.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Repository.Dama
{
    public class ARTVisitsRepository : IARTVisitsRepository
    {
        public async Task<List<ARTVisitViewModel>> GetARTVisits(int numberOfDaysBeforeAppointment)
        {
            DateTime dueDate = DateTime.Now.AddDays(numberOfDaysBeforeAppointment);
            using(var db = new DamaContext())
            {
                var rows = await db.Artvisits
                    .Select(visit => new ARTVisitViewModel { 
                        Refline = visit.Refline,
                        BaselineCode = visit.BaselineCode,
                        PatientStatus = visit.PatientStatus,
                        NextAppointmentDate = visit.NextAppointmentDate,
                        Artsite = visit.Artsite,
                        PhoneNumber = visit.BaselineCodeNavigation.ContactTelephone,
                        IsDeleted = visit.IsDeleted})
                    .Where(visit => visit.IsDeleted == false && visit.NextAppointmentDate >= dueDate)
                    .OrderByDescending(v => v.NextAppointmentDate).Take(1000)
                    .ToListAsync();
                return rows;
            }
        }

        public async Task<ServiceResponse> UpdateVisit(ARTVisit visit)
        {
            throw new NotImplementedException();
        }
    }
}
