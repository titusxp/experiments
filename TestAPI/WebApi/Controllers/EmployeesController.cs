using DataModels.Entities;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IBaseRepository<Employee> baseRepo) : base(baseRepo)
        {
        }
    }
}
