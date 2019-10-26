using Core.Helper2;
using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System.Collections.Generic;

namespace CacheManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachedReportsController : BaseController<CachedReport>
    {
        private ICachedReportsRepository repo => Repository as ICachedReportsRepository;
        public CachedReportsController(ICachedReportsRepository repo) : base(repo)
        {

        }



        // GET api/values
        [HttpPost("GetReport")]
        public ActionResult<CachedReport> GetReport(ReportFilter filter)
        {
            return repo.GetReport(filter);
        }
    }
}
