using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Message
{
    public class MessageCompletedModel
    {
        public Guid MessageId { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public byte[] ReturnData { get; set; }
        //public RoutingTypeEnum RoutingType { get; set; }
    }
}
