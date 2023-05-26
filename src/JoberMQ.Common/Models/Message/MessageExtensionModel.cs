using JoberMQ.Common.Dbos;

namespace JoberMQ.Common.Models.Message
{
    public class MessageExtensionModel<T>
    {
        public T Client { get; set; }
        public MessageDbo Message { get; set; }
    }
}
