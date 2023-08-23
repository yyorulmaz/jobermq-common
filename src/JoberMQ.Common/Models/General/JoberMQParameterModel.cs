using JoberMQ.Common.Enums.Endpoint;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace JoberMQ.Common.Models.General
{
    public class JoberMQParameterModel
    {
        public JoberMQParameterModel()
        {

        }

        public JoberMQParameterModel(string clientKey, string hostName, UrlProtocolEnum urlProtocol, int port)
        {
            ClientKey=clientKey;
            HostName=hostName;
            UrlProtocol=urlProtocol;
            Port=port;
        }

        public string ClientKey { get; set; }
        public string HostName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UrlProtocolEnum UrlProtocol { get; set; }
        public int Port { get; set; }
    }
}
