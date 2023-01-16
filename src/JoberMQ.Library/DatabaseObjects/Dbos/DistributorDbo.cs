using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Enums;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    internal class DistributorDbo : DboPropertyGuidBase, IDboBase
    {
        //[JsonProperty("1")]
        public string DistributorKey { get; set; }
        public DistributorTypeEnum DistributorType { get; set; }
        public PermissionTypeEnum  PermissionType { get; set; }
        public bool IsDurable { get; set; }
    }
}
