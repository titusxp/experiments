using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected IDataContext DatabaseContext { get; set; }
        public BaseRepository(IDataContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public IEnumerable<T> GetAll()
        {
            return DatabaseContext.Set<T>();
        }

        public T AddOrUpdate(T item)
        {
            DatabaseContext.Set<T>().AddOrUpdate(item);
            DatabaseContext.SaveChanges();
            return item;
        }

        public bool Delete(T item)
        {
            DatabaseContext.Set<T>().Remove(item);
            return DatabaseContext.SaveChanges() > 0 ? true : false;
        }
    }
}
