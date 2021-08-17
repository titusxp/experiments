using Alerts.Commands;
using Core.System.SMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alerts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {   
        private readonly IMediator _mediator;

        public SmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("SendSMS")]
        public async Task<bool> SendSMS()
        {
            var command = new CreateSendMessageCommand();
            var response = await _mediator.Send(command);
            return response;
        }
    }
}