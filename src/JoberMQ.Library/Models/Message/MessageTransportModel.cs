using JoberMQ.Library.Models.Client;
using JoberMQ.Library.Models.Job;

namespace JoberMQ.Library.Models.Message
{
    public class MessageTransportModel
    {
        public OperationModel Operation { get; set; } = new OperationModel();
        public ClientInfoModel ClientInfo { get; set; } = new ClientInfoModel();


        public MessageModel Message { get; set; }
        public ConsumingModel MessageConsuming { get; set; }


        public bool IsResult { get; set; }
        public MessageModel ResultMessage { get; set; }
        public ConsumingModel ResultMessageConsuming { get; set; }
    }
}
