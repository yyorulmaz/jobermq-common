using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChildFIFO
    //public interface IChildMemFIFORepository<TKey, TValue> : IMemChildRepository<TKey, TValue>
    //{
    //    #region Data
    //    ConcurrentQueue<TValue> ChildData { get; }
    //    #endregion
    //}
    public interface IMemChildFIFORepository<TKey, TValue>
    {
        #region Data
        IMemRepository<TKey, TValue> MasterData { get; }
        ConcurrentQueue<TValue> ChildData { get; }
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
