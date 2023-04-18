namespace JoberMQ.Library.Models.Routing
{
    public class RoutingFilterModel
    {
        public string FilterRegex { get; set; }
        public string StartsWith { get; set; }
        public string[] Contains { get; set; }
        public string EndsWith { get; set; }
    }
}
