using JoberMQ.Common.Database.Base;

namespace JoberMQ.Common.Dbos
{
    public class SubscriptDbo : DboPropertyGuidBase, IDboBase
    {
        public string ClientKey { get; set; }
        public string QueueKey { get; set; }
        public bool IsDurable { get; set; }

    }
}
