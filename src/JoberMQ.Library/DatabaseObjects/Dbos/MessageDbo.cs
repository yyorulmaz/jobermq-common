using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Enums;
using JoberMQ.Library.DatabaseObjects.Models;
using System;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class MessageDbo : DboPropertyGuidBase, IDboBase
    {
        public OperationModel Operation { get; set; }
        public ProducerModel Producer { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
        public RoutingModel Routing { get; set; }
        public RoutingModel ResultRouting { get; set; }
        public InfoModel Info { get; set; }
        public PriorityTypeEnum PriorityType { get; set; }
        public ConsumingModel Consuming { get; set; }
        public Guid? TriggerGroupsId { get; set; }

        public StatusModel Status { get; set; }



        public Guid? CreatedJobId { get; set; }
        public Guid? CreatedJobDetailId { get; set; }
        public Guid? CreatedJobTransactionId { get; set; }
        public Guid? CreatedJobTransactionDetailId { get; set; }

        public Guid? EventGroupsId { get; set; }
    }
}
