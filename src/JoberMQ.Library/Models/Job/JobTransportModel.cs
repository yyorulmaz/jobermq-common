using JoberMQ.Library.Models.Client;
using JoberMQ.Library.Models.Multiple;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Job
{
    public class JobTransportModel
    {
        public OperationModel Operation { get; set; } = new OperationModel();
        public ClientInfoModel ClientInfo { get; set; } = new ClientInfoModel();
        public InfoModel Info { get; set; } = new InfoModel();
        public PublisherModel Publisher { get; set; } = new PublisherModel();
        public TimingModel Timing { get; set; } = new TimingModel();

        public bool IsResult { get; set; }
        public MessageModel ResultMessage { get; set; }

        public List<MultipleMessageModel> MultipleMessages { get; set; } = new List<MultipleMessageModel>();
    }
}
