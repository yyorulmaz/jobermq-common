using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChildLIFO
    //public interface IChildMemLIFORepository<TKey, TValue> : IMemChildRepository<TKey, TValue>
    //{
    //    #region Data
    //    ConcurrentStack<TValue> ChildData { get; }
    //    #endregion
    //}
    public interface IMemChildLIFORepository<TKey, TValue>
    {
        #region Data
        ConcurrentStack<TValue> ChildData { get; }
        IMemRepository<TKey, TValue> MasterData { get; }
        #endregion

        #region Count
        int Count { get; }
        #endregion

        #region CRUD
        TValue Get();
        bool Add(TKey key, TValue value);
        TValue Remove(TKey key);
        #endregion

        #region Changed
        event Action<TKey, TValue> ChangedAdded;
        event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
