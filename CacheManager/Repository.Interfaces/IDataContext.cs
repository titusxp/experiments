

using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Interfaces
{
    public interface IDataContext
    {
        DbSet<CachedReport> CachedReports { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
