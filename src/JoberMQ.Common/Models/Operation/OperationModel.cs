using JoberMQ.Common.Enums.Operation;

namespace JoberMQ.Common.Models.Operation
{
    public class OperationModel
    {
        public int Version { get; set; }
        public OperationTypeEnum OperationType { get; set; }
    }
}
