using Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BaseController<T> : ApiController where T:class
    {
        protected IBaseRepository<T> Repository { get; set; }
        public BaseController(IBaseRepository<T> baseRepo)
        {
            Repository = baseRepo;
        }
        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]T value)
        {
            Repository.AddOrUpdate(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(T item)
        {
            Repository.Delete(item);
        }
    }
}
