using Alerts.Commands;
using Core.System.SMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alerts.Handlers
{
    public class CreateSendMessageCommandHandler : IRequestHandler<CreateSendMessageCommand, bool>
    {
        private readonly ISMSClient _SMSCLient;
        public CreateSendMessageCommandHandler(ISMSClient smsCLient)
        {
            _SMSCLient = smsCLient;
        }
        public async Task<bool> Handle(CreateSendMessageCommand request, CancellationToken cancellationToken)
        {
            return _SMSCLient.sendMessage();
        }
    }
}
