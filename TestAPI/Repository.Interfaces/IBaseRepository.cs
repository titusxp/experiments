using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T AddOrUpdate(T item);
        bool Delete(T item);
        IEnumerable<T> GetAll();
    }
}