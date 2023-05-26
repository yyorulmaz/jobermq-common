using System.Collections.Generic;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Models.Consuming;
using JoberMQ.Common.Models.Info;
using JoberMQ.Common.Models.Message;
using JoberMQ.Common.Models.Operation;
using JoberMQ.Common.Models.Producer;
using JoberMQ.Common.Models.Publisher;
using JoberMQ.Common.Models.Status;
using JoberMQ.Common.Models.Timing;

namespace JoberMQ.Common.Dbos
{
    public class JobDbo : DboPropertyGuidBase, IDboBase
    {
        public OperationModel Operation { get; set; }
        public ProducerModel Producer { get; set; }
        public InfoModel Info { get; set; }
        public PublisherModel Publisher { get; set; }
        public TimingModel Timing { get; set; }

        public List<JobDetailDbo> JobDetails { get; set; }

        public bool IsJobResultMessage { get; set; }
        public MessageModel JobResultMessage { get; set; }
        public ConsumingModel JobResultMessageConsuming { get; set; }

        public StatusModel Status { get; set; }
    }
}
