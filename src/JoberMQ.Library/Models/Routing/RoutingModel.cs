using JoberMQ.Library.Enums.Routing;

namespace JoberMQ.Library.Models.Routing
{
    public class RoutingModel
    {
        public string DistributorKey { get; set; }
        public string QueueKey { get; set; }
        public string RoutingKey { get; }

        public string ClientKey { get; set; }
        public string EventName { get; set; }


        public string FilterRegex { get; set; }
        public string StartsWith { get; set; }
        public string[] Contains { get; set; }
        public string EndsWith { get; set; }

        public RoutingTypeEnum RoutingType { get; set; }
    }
}
