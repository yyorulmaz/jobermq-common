using JoberMQ.Library.Database.Base;
using JoberMQ.Library.DatabaseObjects.Enums;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    internal class EventSubDbo : DboPropertyGuidBase, IDboBase
    {
        public string EventKey { get; set; }
        public MatchTypeEnum MatchType { get; set; }
        public virtual string ClientKey { get; set; }
        public virtual string ClientGroupKey { get; set; }
    }
}
