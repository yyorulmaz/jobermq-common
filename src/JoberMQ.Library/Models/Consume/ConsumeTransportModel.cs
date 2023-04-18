using JoberMQ.Library.Enums.Consume;

namespace JoberMQ.Library.Models.Consume
{
    public class ConsumeTransportModel
    {
        public ConsumeOperationTypeEnum ConsumeOperationType { get; set; }
        public string DeclareKey { get; set; }
    }
}
