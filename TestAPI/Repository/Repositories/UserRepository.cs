using DataModels.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}
