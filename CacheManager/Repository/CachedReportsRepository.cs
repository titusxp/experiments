using System;
using Core.Helper2;
using DataModels.Entities;
using MongoDB.Bson;
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
            public CachedReport GetById(ObjectId id)
            {
                return Collection.AsQueryable().Where(r => r.TaskId == id).FirstOrDefault();
            }

            public  CachedReport GetByParameters(ReportFilter item)
            {
                return Collection.AsQueryable().Where(r => r.Filter.IsEqualTo(item)).FirstOrDefault();
            }

            public CachedReport GetReport(ReportFilter filter)
            {
                var report = GetById(filter.ReportCacheId) ?? GetByParameters(filter);
                if(report == null)
                {
                    report = InitiateReportGeneration(filter);
                }

                return report;
            }

            private CachedReport InitiateReportGeneration(ReportFilter filter)
            {
                var report = new CachedReport
                {
                    DateGenerated = DateTime.Now,
                    Filter = filter,
                    Status = ReportStatus.InProgress,
                    TaskId = ObjectId.GenerateNewId(),
                    Data = null,
                    ProgressFeedback = "Initializing..."
                };
                report.Filter.ReportCacheId = report.TaskId;
                report = Add(report);
                report.Start();
                return report;
            }
        }
    }

}
