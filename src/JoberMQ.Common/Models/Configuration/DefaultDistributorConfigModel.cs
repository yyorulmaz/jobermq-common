using JoberMQ.Common.Enums.Distributor;
using JoberMQ.Common.Enums.Permission;

namespace JoberMQ.Common.Models.Configuration
{
    public class DefaultDistributorConfigModel
    {
        public string DistributorKey { get; set; }
        public DistributorTypeEnum DistributorType { get; set; }
        public DistributorSearchSourceTypeEnum DistributorSearchSourceType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
        public bool IsDefault { get; set; }
    }
}
