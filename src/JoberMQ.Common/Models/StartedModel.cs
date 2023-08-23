using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Common.Models
{
    public class StartedModel
    {
        public Guid MessageId { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
