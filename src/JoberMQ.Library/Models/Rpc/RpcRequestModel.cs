using JoberMQ.Library.Enums.Message;
using System;

namespace JoberMQ.Library.Models.Rpc
{
    public class RpcRequestModel
    {
        public Guid Id { get; set; }
        public string ProducerId { get; set; }
        public string ConsumerId { get; set; }

        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
    }
}
