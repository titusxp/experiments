using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Database
{
    namespace Dama.Test.Console
    {
        public abstract class BaseRepository<T> : IBaseRepository<T>
        {
            private IMongoDBClient<T> Client;
            protected IMongoCollection<T> Collection => this.Client?.Collection;
            public BaseRepository(IMongoDBClient<T> client)
            {
                Client = client;
            }

            public T Add(T item)
            {
                try
                {
                    Collection.InsertOne(item);
                    return item;
                }
                catch(Exception ex)
                {
                    return default(T);
                }
            }

            public abstract DeleteResult Delete(T item);

            public abstract T Get(T item);

            public List<T> GetAll()
            {
                return this.Collection.AsQueryable().ToList<T>();
            }

            
            public T Update(T item)
            {
                var existing = Get(item);
                if(existing != null)
                {
                    Delete(existing);
                }
                Add(item);
                return item;
            }
        }
    }

}
