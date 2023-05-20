using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Enums.Queue;

namespace JoberMQ.Library.Dbos
{
    public class EventSubDbo : DboPropertyGuidBase, IDboBase
    {
        public string EventKey { get; set; }
        public MatchTypeEnum MatchType { get; set; }
        public virtual string ClientKey { get; set; }
        public virtual string ClientGroupKey { get; set; }

    }
}
