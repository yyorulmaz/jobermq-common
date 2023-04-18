using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Message
{
    public class MessageStartedModel
    {
        public Guid MessageId { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
