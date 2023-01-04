using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Repository.Implementation.Mem.Default
{
    public class DfMemChildFIFORepository<TKey, TValue> : IMemChildFIFORepository<TKey, TValue>
    {
        #region Constructor
        public DfMemChildFIFORepository(IMemRepository<TKey, TValue> masterData)
        {
            this.masterData = masterData;
            childData = new ConcurrentQueue<TValue>();
        }
        #endregion

        #region Data
        private readonly IMemRepository<TKey, TValue> masterData;
        public IMemRepository<TKey, TValue> MasterData => masterData;


        private readonly ConcurrentQueue<TValue> childData;
        public ConcurrentQueue<TValue> ChildData => childData;
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
                childData.Enqueue(value);
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
            var result = childData.TryDequeue(out var value);
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
