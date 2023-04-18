using JoberMQ.Library.Enums.Status;
using System;

namespace JoberMQ.Library.Models
{
    public class StatusModel
    {
        public bool IsCompleted { get; set; }
        public bool IsError { get; set; }
        public StatusTypeMessageEnum? StatusTypeMessage { get; set; }
        public DateTime? TempAgainDate { get; set; }
    }
}
