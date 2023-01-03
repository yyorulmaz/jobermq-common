using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChildPriority
    public interface IChildMemGeneralRepository<TKey, TValue> : IChildMemRepository<TKey, TValue>
    {
        #region Data
        ConcurrentDictionary<TKey, TValue> ChildData { get; }
        #endregion
    }
}
