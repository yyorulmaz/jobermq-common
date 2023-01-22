using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace JoberMQ.Library.Database.Repository.Implementation.Mem.Default
{
    public class DfMemChildGeneralRepository<TKey, TValue> : IMemChildGeneralRepository<TKey, TValue>
    {
        #region Constructor
        public DfMemChildGeneralRepository(IMemRepository<TKey, TValue> masterData)
        {
            this.masterData = masterData;
            childData = new ConcurrentDictionary<TKey, TValue>();
        }
        #endregion

        #region Data
        private readonly IMemRepository<TKey, TValue> masterData;
        public IMemRepository<TKey, TValue> MasterData => masterData;


        private readonly ConcurrentDictionary<TKey, TValue> childData;
        public ConcurrentDictionary<TKey, TValue> ChildData => childData;
        #endregion

        #region Count
        public int Count => childData.Count;
        #endregion

        #region CRUD
        public TValue Get(TKey key)
        {
            childData.TryGetValue(key, out TValue value);
            return value;
        }
        public TValue Get(Func<TValue, bool> filter)
        {
            return childData.Values.FirstOrDefault(filter);
        }
        public bool Add(TKey key, TValue value)
        {
            masterData.Add(key, value);
            var result = childData.TryAdd(key, value);
            if (result)
                ChangedAdded?.Invoke(key, value);
            return result;
        }
        public bool Update(TKey key, TValue value)
        {
            masterData.Update(key, value);
            var result = childData.TryUpdate(key, value, value);
            if (result)
                ChangedUpdated?.Invoke(key, value);
            return result;
        }
        public TValue Remove(TKey key)
        {
            masterData.Remove(key);
            childData.TryRemove(key, out TValue value);
            if (value != null)
                ChangedRemoved?.Invoke(key, value);
            return value;
        }
        #endregion

        #region Changed
        public event Action<TKey, TValue> ChangedAdded;
        public event Action<TKey, TValue> ChangedUpdated;
        public event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
