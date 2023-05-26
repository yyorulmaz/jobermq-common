using System;
using JoberMQ.Common.Database.Base;

namespace JoberMQ.Common.Dbos
{
    public class JobTransactionDetailDbo : DboPropertyGuidBase, IDboBase
    {
        public Guid? JobTransactionId { get; set; }
        public bool IsResultMessageClientSend { get; set; }
        public Guid? CreatedJobId { get; set; }
        public Guid? CreatedJobDetailId { get; set; }
    }
}
