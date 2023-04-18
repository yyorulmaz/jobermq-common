using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Models;
using System;

namespace JoberMQ.Library.Dbos
{
    public class MessageDbo : DboPropertyGuidBase, IDboBase
    {
        public OperationModel Operation { get; set; }
        public ProducerModel Producer { get; set; }

        public MessageModel Message { get; set; }
        public bool IsResult { get; set; }
        public MessageModel ResultMessage { get; set; }

        public Guid? TriggerGroupsId { get; set; }

        public Guid? CreatedJobId { get; set; }
        public Guid? CreatedJobDetailId { get; set; }
        public Guid? CreatedJobTransactionId { get; set; }
        public Guid? CreatedJobTransactionDetailId { get; set; }

        public Guid? EventGroupsId { get; set; }
        public Guid? FilterGroupsId { get; set; }


        public StatusModel Status { get; set; }
    }
}
