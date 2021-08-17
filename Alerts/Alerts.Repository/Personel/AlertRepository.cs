using Alerts.Models.Personel;
using Alerts.Repository.Contracts.Personel;
using Alerts.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Repository.Personel
{
    public class AlertRepository : IAlertRepository
    {
        public async Task<List<Alert>> GetAlerts()
        {
            using(var context = new PersonelContext())
            {
                var alerts = await context.Alerts.ToListAsync();
                return  alerts;

            }
        }
    }
}
