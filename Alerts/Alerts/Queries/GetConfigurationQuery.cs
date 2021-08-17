using Alerts.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.Queries
{
    public class GetConfigurationQuery : IRequest<ServiceResponse<Configuration>>
    {
        public string id { get; set; }
        public GetConfigurationQuery(string _id)
        {
            id = _id;
        }
    }
}
