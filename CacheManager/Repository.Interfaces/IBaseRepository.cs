
using MongoDB.Driver;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T> 
    {
        T Add(T item);
        T Update(T item);
        T Get(T item);
        List<T> GetAll();
        DeleteResult Delete(T item);
    }
}