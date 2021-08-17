using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerts.Domain.Contracts.Personnel;
using Alerts.Models.Common;
using Alerts.Models.Personel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alerts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelAlertsController : ControllerBase
    {
        private readonly IAlertDomain _domain;
        public PersonelAlertsController(IAlertDomain domain)
        {
            _domain = domain;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<Alert>>> Get()
        {
            var alerts =  await _domain.GetAlerts();
            return new ServiceResponse<List<Alert>>
            {
                Success = true,
                Message = "OK",
                Data = alerts
            };
        }

        [HttpGet]
        [Route("SendMonthlyAlerts")]
        public async Task<ServiceResponse<MessageResponse>> SendMonthlyAlerts()
        {
            var response = await _domain.SendMonthlyAlerts();
            return new ServiceResponse<MessageResponse>
            {
                Success = true,
                Message = "OK",
                Data = response
            };
        }
    }
}