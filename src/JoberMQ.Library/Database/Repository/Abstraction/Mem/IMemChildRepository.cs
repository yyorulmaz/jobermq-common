using System;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChild
    public interface IMemChildRepository<TKey, TValue>
    {
        #region Data
        IMemRepository<TKey, TValue> MasterData { get; }
        #endregion

        #region Count
        int Count { get; }
        #endregion

        #region CRUD
        TValue Get();
        TValue Get(TKey key);
        bool Add(TKey key, TValue value);
        TValue Remove(TKey key);
        #endregion

        #region Changed
        event Action<TKey, TValue> ChangedAdded;
        event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
