using DataModels.Entities;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    public class UsersController : BaseController<User>
    {
        public UsersController(IBaseRepository<User> baseRepo) : base(baseRepo)
        {
        }
    }
}
