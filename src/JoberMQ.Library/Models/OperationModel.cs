using JoberMQ.Library.Enums.Operation;

namespace JoberMQ.Library.Models
{
    public class OperationModel
    {
        public int Version { get; set; }
        public OperationTypeEnum OperationType { get; set; }
    }
}
