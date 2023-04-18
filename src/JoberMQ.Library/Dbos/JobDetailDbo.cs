using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Models;
using System;

namespace JoberMQ.Library.Dbos
{
    public class JobDetailDbo : DboPropertyGuidBase, IDboBase
    {
        public Guid? JobId { get; set; }

        public MessageModel Message { get; set; }


        public bool IsResultMessage { get; set; }
        public MessageModel ResultMessage { get; set; }
    }
}
