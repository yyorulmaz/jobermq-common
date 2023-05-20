using JoberMQ.Library.Enums.Consume;
using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Models.Consume
{
    public class ConsumeRequestModel
    {
        public ConsumeOperationTypeEnum ConsumeOperationType { get; set; }
        public ConsumeTypeEnum ConsumeType { get; set; }
        public string DeclareKey { get; set; }
        public ConcurrentDictionary<Guid, ConsumeModel> Consuming { get; set; }
    }
}
