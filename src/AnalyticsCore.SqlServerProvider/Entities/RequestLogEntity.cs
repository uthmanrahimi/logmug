using System;

namespace AnalyticsCore.SqlServerProvider.Entities
{
    public class RequestLogEntity
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public string IPAddress { get; set; }
        public string Referer { get; set; }
        public string HttpMethod { get; set; }
    }
}
