﻿using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Enums.Permission;
using JoberMQ.Library.Enums.Queue;

namespace JoberMQ.Library.Dbos
{
    public class QueueDbo : DboPropertyGuidBase, IDboBase
    {
        public string DistributorKey { get; set; }
        public string QueueKey { get; set; }
        public MatchTypeEnum MatchType { get; set; }
        public SendTypeEnum SendType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
    }
}