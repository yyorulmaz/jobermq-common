using JoberMQ.Library.Enums.Client;
using System.Collections.Concurrent;
using System;
using JoberMQ.Library.Models.Consume;

namespace JoberMQ.Library.Models.Client
{
    public class ClientInfoDataModel
    {
        public ClientTypeEnum ClientType { get; set; }
        public string ClientKey { get; set; }
        public bool IsOfflineClient { get; set; }
        public bool IsClientActive { get; set; }
    }
}
