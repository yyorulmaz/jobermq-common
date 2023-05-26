using JoberMQ.Common.Enums.Client;

namespace JoberMQ.Common.Models.Client
{
    public class ClientInfoDataModel
    {
        public ClientTypeEnum ClientType { get; set; }
        public string ClientKey { get; set; }
        public bool IsOfflineClient { get; set; }
        public bool IsClientActive { get; set; }
    }
}
