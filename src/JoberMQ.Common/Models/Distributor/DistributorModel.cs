using JoberMQ.Common.Enums.Distributor;
using JoberMQ.Common.Enums.Permission;

namespace JoberMQ.Common.Models.Distributor
{
    public class DistributorModel
    {
        public DistributorModel()
        {

        }
        public DistributorModel(string distributorKey, DistributorTypeEnum? distributorType, DistributorSearchSourceTypeEnum? distributorSearchSourceType, PermissionTypeEnum? permissionType, bool? isDurable)
        {
            DistributorKey = distributorKey;
            DistributorType = distributorType;
            DistributorSearchSourceType = distributorSearchSourceType;
            PermissionType = permissionType;
            IsDurable = isDurable;
            IsDefault = false;
        }

        public string DistributorKey { get; set; }
        public DistributorTypeEnum? DistributorType { get; set; }
        public DistributorSearchSourceTypeEnum? DistributorSearchSourceType { get; set; }
        public PermissionTypeEnum? PermissionType { get; set; }
        public bool? IsDurable { get; set; }
        public bool IsDefault { get; set; }
    }
}
