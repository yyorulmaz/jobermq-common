using JoberMQ.Common.Enums.Permission;
using JoberMQ.Common.Enums.Queue;

namespace JoberMQ.Common.Models.Queue
{
    public class QueueModel
    {
        public QueueModel()
        {

        }

        public QueueModel(string queueKey, string[] tags, QueueMatchTypeEnum? queueMatchType, QueueOrderOfSendingTypeEnum? queueOrderOfSendingType, PermissionTypeEnum permissionType, bool isDurable, bool isActive)
        {
            QueueKey=queueKey;
            Tags=tags;
            QueueMatchType=queueMatchType;
            QueueOrderOfSendingType=queueOrderOfSendingType;
            PermissionType=permissionType;
            IsDurable=isDurable;
            IsDefault=false;
            IsActive=isActive;
        }

        public string QueueKey { get; set; }
        public string[] Tags { get; set; }
        public QueueMatchTypeEnum? QueueMatchType { get; set; }
        public QueueOrderOfSendingTypeEnum? QueueOrderOfSendingType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
