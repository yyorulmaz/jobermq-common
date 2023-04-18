using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Models;
using System.Collections.Generic;

namespace JoberMQ.Library.Dbos
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
