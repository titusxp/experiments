using Alerts.Models.Common;
using Alerts.Repository.Contracts.System;
using MyCouch;
using MyCouch.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerts.Repository.System
{
    public class ConfigurationsRepository : CouchRepositoryBase<Configuration>, IConfigurationsRepository
    {   
    }
}
