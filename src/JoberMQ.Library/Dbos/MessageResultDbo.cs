using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Enums.Message;
using JoberMQ.Library.Models;
using JoberMQ.Library.Models.Routing;
using System;

namespace JoberMQ.Library.Dbos
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
