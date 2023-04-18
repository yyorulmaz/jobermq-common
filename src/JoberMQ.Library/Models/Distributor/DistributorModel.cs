using JoberMQ.Library.Enums.Distributor;
using JoberMQ.Library.Enums.Permission;

namespace JoberMQ.Library.Models.Distributor
{
    public class DistributorModel
    {
        public DistributorOperationTypeEnum DistributorOperationType { get; set; }
        public string DistributorKey { get; set; }
        public DistributorTypeEnum DistributorType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
    }
}
