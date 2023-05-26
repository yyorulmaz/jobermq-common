using System;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Enums.Message;
using JoberMQ.Common.Models.Info;
using JoberMQ.Common.Models.Routing;
using JoberMQ.Common.Models.Status;

namespace JoberMQ.Common.Dbos
{
    public class MessageResultDbo : DboPropertyGuidBase, IDboBase
    {
        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
        public RoutingModel Routing { get; set; }
        public InfoModel Info { get; set; }
        public StatusModel Status { get; set; }

        public Guid? CreatedJobId { get; set; }
        public Guid? CreatedJobDetailId { get; set; }
        public Guid? CreatedJobTransactionId { get; set; }
        public Guid? CreatedJobTransactionDetailId { get; set; }
    }
}
