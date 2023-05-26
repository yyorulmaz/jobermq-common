using JoberMQ.Common.Enums.Routing;

namespace JoberMQ.Common.Models.Routing
{
    public class RoutingModel
    {
        public string DistributorKey { get; set; }
        public string RoutingKey { get; set; } //regex veya text
        public string QueueKey { get; set; }
        public string ClientTag { get; set; } //regex

        public string ClientKey { get; set; }


        public string FilterRegex { get; set; }
        public string StartsWith { get; set; }
        public string[] Contains { get; set; }
        public string EndsWith { get; set; }

        public RoutingTypeEnum RoutingType { get; set; }
    }
}
