using Alerts.Models.Common;
using Alerts.Queries;
using Alerts.Repository.Contracts.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alerts.Handlers
{
    public class GetConfigurationQueryHandler : IRequestHandler<GetConfigurationQuery, ServiceResponse<Configuration>>
    {
        private readonly IConfigurationsRepository _repo;
        public GetConfigurationQueryHandler(IConfigurationsRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse<Configuration>> Handle(GetConfigurationQuery request, CancellationToken cancellationToken)
        {
            var response = await _repo.GetEntity(request.id);
            return response;
        }
    }
}
