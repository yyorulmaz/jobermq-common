using JoberMQ.Common.Enums.Endpoint;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace JoberMQ.Common.Models
{
    public class JoberMQParameterModel
    {
        public string ClientKey { get; set; }
        public string HostName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UrlProtocolEnum UrlProtocol { get; set; }
        public int Port { get; set; }
    }
}
