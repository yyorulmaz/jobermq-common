using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Enums.Permission;
using JoberMQ.Common.Enums.Queue;

namespace JoberMQ.Common.Dbos
{
    public class QueueDbo : DboPropertyGuidBase, IDboBase
    {
        public string QueueKey { get; set; }
        public QueueMatchTypeEnum QueueMatchType { get; set; }
        public QueueOrderOfSendingTypeEnum QueueOrderOfSendingType { get; set; }
        public string[] Tags { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
        public bool IsDefault { get; set; }
    }
}
