using Core.Helper2;
using DataModels.Entities;

namespace Repository.Interfaces
{
    public interface ICachedReportsRepository : IBaseRepository<CachedReport>
    {
        CachedReport GetReport(ReportFilter filter);
    }
}