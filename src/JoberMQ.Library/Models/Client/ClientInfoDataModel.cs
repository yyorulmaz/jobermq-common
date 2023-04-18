using JoberMQ.Library.Enums.Client;

namespace JoberMQ.Library.Models.Client
{
    public class ClientInfoDataModel
    {
        public ClientTypeEnum ClientType { get; set; }
        public string ClientKey { get; set; }
        public string ClientGroupKey { get; set; }
        public bool IsOfflineClient { get; set; }
        public bool IsClientActive { get; set; }
    }
}
