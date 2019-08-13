using DataModels.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDataContext dbContext) : base(dbContext)
        {

        }
    }
}
