using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Enums.Distributor;
using JoberMQ.Common.Enums.Permission;

namespace JoberMQ.Common.Dbos
{
    public class DistributorDbo : DboPropertyGuidBase, IDboBase
    {
        //[JsonProperty("1")]
        public string DistributorKey { get; set; }
        public DistributorTypeEnum DistributorType { get; set; }
        public DistributorSearchSourceTypeEnum DistributorSearchSourceType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
        public bool IsDefault { get; set; }
    }
}
