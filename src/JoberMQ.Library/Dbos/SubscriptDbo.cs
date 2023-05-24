using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Enums.Queue;

namespace JoberMQ.Library.Dbos
{
    public class SubscriptDbo : DboPropertyGuidBase, IDboBase
    {
        public string EventKey { get; set; }
        public QueueMatchTypeEnum MatchType { get; set; }
        public virtual string ClientKey { get; set; }

    }
}
