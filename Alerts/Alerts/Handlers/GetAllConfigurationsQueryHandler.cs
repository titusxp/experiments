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
    public class GetAllConfigurationsQueryHandler : IRequestHandler<GetAllConfigurationsQuery, ServiceResponse<List<Configuration>>>
    {
        private readonly IConfigurationsRepository _repo;
        public GetAllConfigurationsQueryHandler(IConfigurationsRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse<List<Configuration>>> Handle(GetAllConfigurationsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repo.GetEntities();
            return response;

        }
    }
}
