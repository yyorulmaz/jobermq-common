using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Enums;
using JoberMQ.Library.DatabaseObjects.Models;
using System;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class JobDetailDbo : DboPropertyGuidBase, IDboBase
    {
        public Guid? JobId { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
        public PriorityTypeEnum PriorityType { get; set; } = PriorityTypeEnum.None;

        public OperationModel Operation { get; set; }
        public RoutingModel Routing { get; set; }
        public RoutingModel ResultRouting { get; set; }
        public ConsumingModel Consuming { get; set; }
    }
}
