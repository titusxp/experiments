using Alerts.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.Queries
{
    public class GetAllConfigurationsQuery : IRequest<ServiceResponse<List<Configuration>>>
    {
    }
}
