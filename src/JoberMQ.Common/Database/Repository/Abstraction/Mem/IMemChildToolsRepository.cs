using System;
using System.Collections.Concurrent;

namespace JoberMQ.Common.Database.Repository.Abstraction.Mem
{
    //IDbChildPriority
    //public interface IChildMemGeneralRepository<TKey, TValue> : IMemChildRepository<TKey, TValue>
    //{
    //    #region Data
    //    ConcurrentDictionary<TKey, TValue> ChildData { get; }
    //    #endregion
    //}
    public interface IMemChildToolsRepository<TKey, TValue>
    {
        #region MasterDataActivite
        bool IsMasterToChildAdded { get; set; }
        Func<TValue, bool> IsMasterToChildAddedFilter { get; set; }
        bool IsMasterToChildUpdated { get; set; }
        Func<TValue, bool> IsMasterToChildUpdatedFilter { get; set; }
        bool IsMasterToChildRemoved { get; set; }
        Func<TValue, bool> IsMasterToChildRemovedFilter { get; set; }


        bool IsChildToMasterAdded { get; set; }
        Func<TValue, bool> IsChildToMasterAddedFilter { get; set; }
        bool IsChildToMasterUpdated { get; set; }
        Func<TValue, bool> IsChildToMasterUpdatedFilter { get; set; }
        bool IsChildToMasterRemoved { get; set; }
        Func<TValue, bool> IsChildToMasterRemovedFilter { get; set; }
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
        TValue Get(Func<TValue, bool> filter);
        bool Add(TKey key, TValue value);
        bool Update(TKey key, TValue value);
        TValue Remove(TKey key, TValue value);
        #endregion

        #region Changed
        event Action<TKey, TValue> ChangedAdded;
        event Action<TKey, TValue> ChangedUpdated;
        event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
