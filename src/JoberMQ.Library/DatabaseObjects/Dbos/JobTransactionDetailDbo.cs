using JoberMQ.Library.Database.Base;
using System;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class JobTransactionDetailDbo : DboPropertyGuidBase, IDboBase
    {
        public bool IsResultMessageClientSend { get; set; }
        public Guid? CreatedJobId { get; set; }
        public Guid? CreatedJobDetailId { get; set; }

    }
}
