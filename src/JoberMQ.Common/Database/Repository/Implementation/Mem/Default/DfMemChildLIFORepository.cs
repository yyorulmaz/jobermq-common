using System;
using System.Collections.Concurrent;
using JoberMQ.Common.Database.Repository.Abstraction.Mem;

namespace JoberMQ.Common.Database.Repository.Implementation.Mem.Default
{
    public class DfMemChildLIFORepository<TKey, TValue> : IMemChildLIFORepository<TKey, TValue>
    {
        #region Constructor
        public DfMemChildLIFORepository(IMemRepository<TKey, TValue> masterData)
        {
            this.masterData = masterData;
            childData = new ConcurrentStack<TValue>();
        }
        #endregion

        #region Data
        private readonly IMemRepository<TKey, TValue> masterData;
        public IMemRepository<TKey, TValue> MasterData => masterData;


        private readonly ConcurrentStack<TValue> childData;
        public ConcurrentStack<TValue> ChildData => childData;
        #endregion

        #region Count
        public int Count => childData.Count;
        #endregion

        #region CRUD
        public TValue Get()
        {
            childData.TryPeek(out var value);
            return value;
        }
        public bool Add(TKey key, TValue value)
        {
            try
            {
                masterData.Add(key, value);
                childData.Push(value);
                ChangedAdded?.Invoke(key, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TValue Remove(TKey key)
        {
            masterData.Remove(key);
            var result = childData.TryPeek(out var value);
            if (result)
                ChangedRemoved?.Invoke(key, value);
            return value;
        }
        #endregion

        #region Changed
        public event Action<TKey, TValue> ChangedAdded;
        public event Action<TKey, TValue> ChangedRemoved;
        #endregion
    }
}
