﻿namespace JoberMQ.Library.Models
{
    public class ConsumingModel
    {
        public bool IsConsumingRetryPause { get; set; }
        public int ConsumingRetryMaxCount { get; set; }
        public int ConsumingRetryCounter { get; set; }
        public string ClientKey { get; set; }
    }
}
