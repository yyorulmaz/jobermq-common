using JoberMQ.Common.Enums.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Common.Models
{
    public class CompletedModel
    {
        public Guid MessageId { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public byte[] ReturnData { get; set; }
        public RoutingTypeEnum RoutingType { get; set; }
    }
}
