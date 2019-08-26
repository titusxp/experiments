using DataModels.Entities;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    public class EmployeesController : BaseController<Employee>, IEmployeesController
    {
        public EmployeesController(IEmployeeRepository baseRepo) : base(baseRepo)
        {
        }
    }
}
