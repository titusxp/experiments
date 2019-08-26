using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace CacheManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachedReportsController : BaseController<CachedReport>
    {
        public CachedReportsController(ICachedReportsRepository repo) : base(repo)
        {

        }
    }
}
