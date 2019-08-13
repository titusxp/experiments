using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IBaseController<T> where T : class
    {
        void Delete(T item);
        string Get(int id);
        IEnumerable<T> GetAll();
        void Post(T value);
        void Put(int id, string value);
    }
}