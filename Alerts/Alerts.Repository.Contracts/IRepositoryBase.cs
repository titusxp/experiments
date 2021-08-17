using Alerts.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alerts.Repository.Contracts
{
    public interface IRepositoryBase<T>
        where T: class
    {
        Task<ServiceResponse<List<T>>> GetEntities();
        Task<ServiceResponse<T>> GetEntity(string id);
        Task<ServiceResponse<T>> PostEntity(T entity);
        Task<ServiceResponse<T>> PutEntity(string id, T entity);
        Task<bool> DeleteEntity(string id);
    }
}
