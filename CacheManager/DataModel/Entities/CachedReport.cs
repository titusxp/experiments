
using Core.Helper2;
using System;

namespace DataModels.Entities
{
    public class CachedReport 
    {
        public Guid TaskId { get; set; }
        public object Data { get; set; }
        public ReportFilter Filter { get; set; }
        public DateTime? DateGenerated { get; set; }
        public ReportStatus Status { get; set; }
    }
}
