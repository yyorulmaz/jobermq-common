using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDb
    public interface IMemRepository<TKey, TValue>
    {
        #region Data
        ConcurrentDictionary<TKey, TValue> MasterData { get; }
        #endregion

        #region Count
        int Count { get; }
        #endregion

        #region CRUD
        TValue Get(TKey key);
        TValue Get(Func<TValue, bool> filter);
        List<TValue> GetAll(Func<TValue, bool> filter = null);
        bool Add(TKey key, TValue value);
        bool Update(TKey key, TValue value);
        TValue Remove(TKey key);
        #endregion

        #region Changed
        event Action<TValue> ChangedAdded;
        event Action<TValue> ChangedUpdated;
        event Action<TValue> ChangedRemoved;
        #endregion
    }
}
