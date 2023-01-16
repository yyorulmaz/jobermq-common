using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    internal class QueueDbo : DboPropertyGuidBase, IDboBase
    {
        public string QueueKey { get; set; }
        public MatchTypeEnum MatchType { get; set; }
        public SendTypeEnum SendType { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }
        public bool IsDurable { get; set; }
    }
}
