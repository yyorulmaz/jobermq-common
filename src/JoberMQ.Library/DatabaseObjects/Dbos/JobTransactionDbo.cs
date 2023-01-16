using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Models;
using System;
using System.Collections.Generic;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class JobTransactionDbo : DboPropertyGuidBase, IDboBase
    {
        public bool IsTrigger { get; set; }
        public bool ErrorWorkflowStop { get; set; }
        public Guid? TriggerJobId { get; set; }
        public bool IsTriggerMain { get; set; }
        public Guid? TriggerGroupsId { get; set; }


        public bool IsResultMessageClientSend { get; set; }
        public StatusModel Status { get; set; }
        public int Version { get; set; }
        public Guid CreatedJobId { get; set; }

        public List<JobTransactionDetailDbo> JobTransactioDetails { get; set; }

    }
}
