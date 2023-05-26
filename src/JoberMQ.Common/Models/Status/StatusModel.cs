using System;
using JoberMQ.Common.Enums.Status;

namespace JoberMQ.Common.Models.Status
{
    public class StatusModel
    {
        public bool IsCompleted { get; set; }
        public bool IsError { get; set; }
        public StatusTypeMessageEnum? StatusTypeMessage { get; set; }
        public DateTime? TempAgainDate { get; set; }
    }
}
