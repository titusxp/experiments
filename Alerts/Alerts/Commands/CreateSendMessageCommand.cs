using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.Commands
{
    public class CreateSendMessageCommand : IRequest<bool>
    {
    }
}
