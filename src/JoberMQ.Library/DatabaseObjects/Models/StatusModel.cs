using JoberMQ.Library.DatabaseObjects.Enums;
using System;

namespace JoberMQ.Library.DatabaseObjects.Models
{
    public class StatusModel
    {
        public bool IsCompleted { get; set; }
        public bool IsError { get; set; }
        public StatusTypeMessageEnum? StatusTypeMessage { get; set; }
        public DateTime? TempAgainDate { get; set; }
    }
}
