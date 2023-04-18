using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Enums.Distributor;
using JoberMQ.Library.Enums.Permission;

namespace JoberMQ.Library.Dbos
{
    public class DistributorDbo : DboPropertyGuidBase, IDboBase
    {
        //[JsonProperty("1")]
        public string DistributorKey { get; set; }
        public DistributorTypeEnum DistributorType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
    }
}
