using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChildFIFO
    public interface IChildMemFIFORepository<TKey, TValue> : IChildMemRepository<TKey, TValue>
    {
        #region Data
        ConcurrentQueue<TValue> ChildData { get; }
        #endregion
    }
}
