using System;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Models.Message;

namespace JoberMQ.Common.Dbos
{
    public class JobDetailDbo : DboPropertyGuidBase, IDboBase
    {
        public Guid? JobId { get; set; }

        public MessageModel Message { get; set; }


        public bool IsResultMessage { get; set; }
        public MessageModel ResultMessage { get; set; }
    }
}
