using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Abstraction.Mem
{
    //IDbChildPriority
    //public interface IChildMemGeneralRepository<TKey, TValue> : IMemChildRepository<TKey, TValue>
    //{
    //    #region Data
    //    ConcurrentDictionary<TKey, TValue> ChildData { get; }
    //    #endregion
    //}
    public interface IMemChildGeneralRepository<TKey, TValue>
    {
        #region MasterDataActivite
        bool IsMasterDataActiviteAdded { get; set; }
        bool IsMasterDataActiviteUpdated { get; set; }
        bool IsMasterDataActiviteRemoved { get; set; } 
        #endregion

        #region Data
        ConcurrentDictionary<TKey, TValue> ChildData { get; }
        IMemRepository<TKey, TValue> MasterData { get; }
        #endregion

        #region Count
        int Count { get; }
        #endregion

        #region CRUD
        TValue Get(TKey key);
        bool Add(TKey key, TValue value);
        bool Update(TKey key, TValue value);
        TValue Remove(TKey key);
        #endregion

        #region Changed
        event Action<TKey, TValue> ChangedAdded;
        event Action<TKey, TValue> ChangedUpdated;
        event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
