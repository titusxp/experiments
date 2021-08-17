using Alerts.Models.Common;
using Alerts.Repository.Contracts;
using MyCouch;
using MyCouch.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.Repository
{
    public class CouchRepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public static readonly string _server = "http://emerick:Admin123@localhost:5984/";
        public static readonly string db = "alerts_db";

        public async Task<ServiceResponse<List<T>>> GetEntities()
        {
            using (var client = new MyCouchClient(_server, db))
            {
                try
                {
                    var query = await client.Views.QueryAsync<T>(new QueryViewRequest("configurations", "configurations-view"));
                    var configurations = query.Rows.Select(r => r.Value).ToList();
                    ServiceResponse<List<T>> response = new ServiceResponse<List<T>>
                    {
                        Success = true,
                        Message = "OK",
                        Data = configurations
                    };
                    return response;
                } catch(Exception ex)
                {
                    ServiceResponse<List<T>> response = new ServiceResponse<List<T>>
                    {
                        Success = false,
                        Message = ex.Message,
                        Data = null
                    };
                    return response;
                }
            }
        }

        public async Task<ServiceResponse<T>> GetEntity(string id)
        {
            using (var client = new MyCouchClient(_server, db))
            {
                var query = await client.Entities.GetAsync<T>(id);
                if (query.IsSuccess)
                {
                    return new ServiceResponse<T>
                    {
                        Success = true,
                        Message = "OK",
                        Data = query.Content,
                    };
                        
                }
                else
                {
                    return new ServiceResponse<T>
                    {
                        Success = false,
                        Message = "No Record Found",
                        Data = null,
                    };
                }
            }
        }

        public async Task<ServiceResponse<T>> PostEntity(T entity)
        {
            using (var client = new MyCouchClient(_server, db))
            {
                var response = await client.Entities.PostAsync(entity);
                if (response.IsSuccess)
                {
                    return new ServiceResponse<T>
                    {
                        Success = true,
                        Message = "OK",
                        Data = response.Content,
                    };
                }
                else
                {
                    return new ServiceResponse<T>
                    {
                        Success = false,
                        Message = "No Record Found",
                        Data = null,
                    };
                }
            }
        }

        public async Task<ServiceResponse<T>> PutEntity(string id, T entity)
        {
            using (var client = new MyCouchClient(_server, db))
            {
                var res = await client.Entities.GetAsync<T>(id);
                var response = await client.Entities.PutAsync<T>(res.Id, res.Rev, entity);
                if (response.IsSuccess)
                {
                    return new ServiceResponse<T>
                    {
                        Success = true,
                        Message = "OK",
                        Data = response.Content,
                    };
                }
                else
                {
                    return new ServiceResponse<T>
                    {
                        Success = false,
                        Message = "No Record Found",
                        Data = null,
                    };
                }
            }
        }

        public async Task<bool> DeleteEntity(string id)
        {
            using (var client = new MyCouchClient(_server, db))
            {
                var res = await client.Entities.GetAsync<T>(id);
                var entity = new DeleteModel
                {
                    _id = res.Id,
                    _rev = res.Rev
                };
                var response = await client.Entities.DeleteAsync(entity);
                return response.IsSuccess;
            }
        }
    }
}
