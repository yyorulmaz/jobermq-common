using System;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Models.Message;
using JoberMQ.Common.Models.Operation;
using JoberMQ.Common.Models.Producer;
using JoberMQ.Common.Models.Status;

namespace JoberMQ.Common.Dbos
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
