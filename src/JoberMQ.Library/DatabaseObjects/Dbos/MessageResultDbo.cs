using JoberMQ.Library.DatabaseObjects.Enums;
using JoberMQ.Library.DatabaseObjects.Models;
using System;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class MessageResultDbo
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
