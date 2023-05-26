using System;
using System.Collections.Generic;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Models.Status;
using JoberMQ.Common.Models.Timing;

namespace JoberMQ.Common.Dbos
{
    public class JobTransactionDbo : DboPropertyGuidBase, IDboBase
    {
        public TimingModel Timing { get; set; }
        public StatusModel Status { get; set; }
        public bool IsResultMessageClientSend { get; set; }
        public Guid CreatedJobId { get; set; }

        public List<JobTransactionDetailDbo> JobTransactioDetails { get; set; }

    }
}
