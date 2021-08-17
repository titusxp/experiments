using Alerts.Models.Common;
using Alerts.Models.Personel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Domain.Contracts.Personnel
{
    public interface IAlertDomain
    {
        Task<List<Alert>> GetAlerts();

        Task<MessageResponse> SendMonthlyAlerts();

    }
}
