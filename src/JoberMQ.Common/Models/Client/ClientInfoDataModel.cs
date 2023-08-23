﻿using JoberMQ.Common.Enums.Client;

namespace JoberMQ.Common.Models.Client
{
    public class ClientInfoDataModel
    {
        public ClientInfoDataModel()
        {
            
        }
        public ClientInfoDataModel(ClientTypeEnum clientType, string clientKey, bool isOfflineClient, bool isClientActive)
        {
            ClientType=clientType;
            ClientKey=clientKey;
            IsOfflineClient=isOfflineClient;
            IsClientActive=isClientActive;
        }

        public ClientTypeEnum ClientType { get; set; }
        public string ClientKey { get; set; }
        public bool IsOfflineClient { get; set; }
        public bool IsClientActive { get; set; }
    }
}
