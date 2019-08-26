using System;
using DataModels.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Interfaces;

namespace Database
{
    namespace Dama.Test.Console
    {
        public class CachedReportsRepository : BaseRepository<CachedReport>, ICachedReportsRepository
        {
            public CachedReportsRepository(IMongoDBClient<CachedReport> conn) : base(conn)
            {

            }

            public override DeleteResult Delete(CachedReport item)
            {
                return Collection.DeleteMany(r => r.TaskId == item.TaskId);
            }

            public override CachedReport Get(CachedReport item)
            {
                return Collection.AsQueryable().Where(r => r.TaskId == item.TaskId).FirstOrDefault();
            }
        }
    }

}
