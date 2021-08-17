using Alerts.Models.Personel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Repository.Contracts.Personel
{
    public interface IAlertRepository
    {
        Task<List<Alert>> GetAlerts();
    }
}
