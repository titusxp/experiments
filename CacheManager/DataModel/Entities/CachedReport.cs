
using Core.Helper2;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataModels.Entities
{
    public class CachedReport
    {
        [BsonId]
        public MongoDB.Bson.ObjectId TaskId { get; set; }
        public object Data { get; set; }
        public ReportFilter Filter { get; set; }
        public DateTime? DateGenerated { get; set; }
        public ReportStatus Status { get; set; }
        public string ProgressFeedback { get; set; }

        public void Start()
        {
            this.Status = ReportStatus.InProgress;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.Filter.ReportUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add(PreservedHeaderNames.SyncToCloud.ToString(), syncToken);

                    var serializedFilter = JsonConvert.SerializeObject(this.Filter);
                    var content = new StringContent(serializedFilter);
                    var response = client.PostAsync(this.Filter.ReportUrl, content);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
