using JoberMQ.Common.Enums.Message;
using JoberMQ.Common.Enums.Priority;
using JoberMQ.Common.Models.Consuming;
using JoberMQ.Common.Models.Info;
using JoberMQ.Common.Models.Routing;

namespace JoberMQ.Common.Models.Message
{
    public class MessageModel
    {
        public MessageTypeEnum MessageType { get; set; }
        public string Message { get; set; }
        public RoutingModel Routing { get; set; }
        public InfoModel Info { get; set; }
        public string GeneralData { get; set; }
        public PriorityTypeEnum PriorityType { get; set; } = PriorityTypeEnum.None;
        public ConsumingModel MessageConsuming { get; set; }
    }
}
