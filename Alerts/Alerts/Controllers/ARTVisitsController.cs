using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerts.Domain.Contracts.Dama;
using Alerts.Models.Common;
using Alerts.Models.Dama;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alerts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ARTVisitsController : ControllerBase
    {
        private readonly IARTVisitDomain _VisitDomain;
        public ARTVisitsController(IARTVisitDomain visitDomain)
        {
            _VisitDomain = visitDomain;
        }

        [HttpGet]
        [Route("GetVisits")]
        public async Task<ServiceResponse<IEnumerable<ARTVisitViewModel>>> GetVisits()
        {
            var visits = await _VisitDomain.GetARTVisits(7);
            return new ServiceResponse<IEnumerable<ARTVisitViewModel>> { 
                Data = visits,
                Success = true,
                Message = "OK"
            };
        }

        [HttpGet]
        [Route("SendAppointmentReminders")]
        public async Task<bool> SendAppointmentReminders()
        {
            var response = await _VisitDomain.SendAppointmentReminders(7);
            return response;
        }

        [HttpGet]
        [Route("sendindividualappointmentreminders")]
        public async Task<MessageResponse> SendIndividualAppointmentReminders()
        {
            var response = await _VisitDomain.SendIndividualAppointmentReminders(7);
            return response;
        }
    }
}