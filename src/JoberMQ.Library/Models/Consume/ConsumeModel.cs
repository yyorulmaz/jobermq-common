using JoberMQ.Library.Enums.Consume;

namespace JoberMQ.Library.Models.Consume
{
    public class ConsumeModel
    {
        public ConsumeTypeEnum ConsumeType { get; set; }
        public string DeclareKey { get; set; }
    }
}
