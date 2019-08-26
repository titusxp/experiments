using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace CacheManager.Controllers
{
    public abstract class BaseController<T> : ControllerBase, IBaseController<T>
    {
        protected IBaseRepository<T> Repository { get; set; }
        public BaseController(IBaseRepository<T> baseRepo)
        {
            Repository = baseRepo;
        }

        [HttpGet]
        public virtual IEnumerable<T> GetAll()
        {
            //var repo = Repository as ICachedReportsRepository;
            //var cachedReports = new List<DataModels.Entities.CachedReport>()
            //{
            //    new DataModels.Entities.CachedReport
            //    {
            //        Data = new object(),
            //        Filter = new Core.Helper2.ReportFilter
            //        {
            //        },
            //        Status = Core.Helper2.ReportStatus.Completed,
            //        TaskId = Guid.NewGuid(),
            //    },
            //    new DataModels.Entities.CachedReport
            //    {
            //        Data = new object(),
            //        Filter = new Core.Helper2.ReportFilter
            //        {
            //        },
            //        Status = Core.Helper2.ReportStatus.Completed,
            //        TaskId = Guid.NewGuid(),
            //    },
            //    new DataModels.Entities.CachedReport
            //    {
            //        Data = new object(),
            //        Filter = new Core.Helper2.ReportFilter
            //        {
            //        },
            //        Status = Core.Helper2.ReportStatus.Completed,
            //        TaskId = Guid.NewGuid(),
            //    },
            //    new DataModels.Entities.CachedReport
            //    {
            //        Data = new object(),
            //        Filter = new Core.Helper2.ReportFilter
            //        {
            //        },
            //        Status = Core.Helper2.ReportStatus.Completed,
            //        TaskId = Guid.NewGuid(),
            //    },
            //};
            //foreach (var report in cachedReports)
            //{
            //    repo.Add(report);
            //}

            //var everything = Repository.GetAll().ToList();
            //return everything;

            return Repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]T value)
        {
            Repository.Update(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(T item)
        {
            Repository.Delete(item);
        }
    }
}
