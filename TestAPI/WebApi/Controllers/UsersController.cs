using DataModels.Entities;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    public class UsersController : BaseController<User>, IUsersController
    {
        public UsersController(IUserRepository baseRepo) : base(baseRepo)
        {
        }
    }
}
