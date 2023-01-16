using JoberMQ.Library.DatabaseObjects.Enums;

namespace JoberMQ.Library.DatabaseObjects.Models
{
    public class RoutingModel
    {
        public RoutingTypeEnum RoutingType { get; set; }
        public bool IsResult { get; set; }
        public string DistributorKey { get; set; }
        public string RoutingKey { get; set; }
        public string ConsumerKey { get; set; }

        public string StartsWith { get; set; }
        public string Contains { get; set; }
        public string EndsWith { get; set; }
    }
}
