using JoberMQ.Library.Enums.Message;
using JoberMQ.Library.Enums.Priority;
using JoberMQ.Library.Models.Routing;

namespace JoberMQ.Library.Models
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
