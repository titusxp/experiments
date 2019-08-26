using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System.Collections.Generic;

namespace CacheManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<Student>
    {
        public StudentsController(IStudentsRepository repo) : base(repo)
        {
            
        }
        public override IEnumerable<Student> GetAll()
        {
            var othr = Repository.GetAll();

            return othr;
        }
    }
}
