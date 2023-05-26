using System;
using System.Collections.Concurrent;
using System.Linq;
using JoberMQ.Common.Database.Repository.Abstraction.Mem;

namespace JoberMQ.Common.Database.Repository.Implementation.Mem.Default
{
    public class DfMemChildToolsRepository<TKey, TValue> : IMemChildToolsRepository<TKey, TValue>
    {
        #region Constructor
        public DfMemChildToolsRepository(
            IMemRepository<TKey, TValue> masterData,

            bool isMasterToChildAdded,
            Func<TValue, bool> isMasterToChildAddedFilter,

            bool isMasterToChildUpdated,
            Func<TValue, bool> isMasterToChildUpdatedFilter,

            bool isMasterToChildRemoved,
            Func<TValue, bool> isMasterToChildRemovedFilter,

            bool isChildToMasterAdded,
            Func<TValue, bool> isChildToMasterAddedFilter,

            bool isChildToMasterUpdated,
            Func<TValue, bool> isChildToMasterUpdatedFilter,

            bool isChildToMasterRemoved,
            Func<TValue, bool> isChildToMasterRemovedFilter)
        {
            this.masterData = masterData;
            childData = new ConcurrentDictionary<TKey, TValue>();

            this.isMasterToChildAdded = isMasterToChildAdded;
            this.isMasterToChildAddedFilter = isMasterToChildAddedFilter;
            this.isMasterToChildUpdated = isMasterToChildUpdated;
            this.isMasterToChildUpdatedFilter = isMasterToChildUpdatedFilter;
            this.isMasterToChildRemoved = isMasterToChildRemoved;
            this.isMasterToChildRemovedFilter = isMasterToChildRemovedFilter;

            this.isChildToMasterAdded = isChildToMasterAdded;
            this.isChildToMasterAddedFilter = isChildToMasterAddedFilter;
            this.isChildToMasterUpdated = isChildToMasterUpdated;
            this.isChildToMasterUpdatedFilter = isChildToMasterUpdatedFilter;
            this.isChildToMasterRemoved = isChildToMasterRemoved;
            this.isChildToMasterRemovedFilter = isChildToMasterRemovedFilter;

            this.masterData.ChangedAdded += MasterData_ChangedAdded;
            this.masterData.ChangedUpdated += MasterData_ChangedUpdated;
            this.masterData.ChangedRemoved += MasterData_ChangedRemoved;
        }
        #endregion

        #region Data
        private IMemRepository<TKey, TValue> masterData;
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
            if (isChildToMasterAdded && isChildToMasterAddedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isChildToMasterAddedFilter) != null)
                {
                    masterData.Add(key, value);
                }
            }
            else if (isChildToMasterAdded && isChildToMasterAddedFilter == null)
            {
                masterData.Add(key, value);
            }

            var result = childData.TryAdd(key, value);
            if (result)
                ChangedAdded?.Invoke(key, value);
            return result;
        }
        public bool Update(TKey key, TValue value)
        {
            if (isChildToMasterUpdated && isChildToMasterUpdatedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isChildToMasterUpdatedFilter) != null)
                {
                    masterData.Update(key, value);
                }
            }
            else if (isChildToMasterUpdated && isChildToMasterUpdatedFilter == null)
            {
                masterData.Update(key, value);
            }

            var result = childData.TryUpdate(key, value, value);
            if (result)
                ChangedUpdated?.Invoke(key, value);
            return result;
        }
        public TValue Remove(TKey key, TValue value)
        {
            if (isChildToMasterRemoved && isChildToMasterRemovedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isChildToMasterRemovedFilter) != null)
                {
                    masterData.Remove(key);
                }
            }
            else if (isChildToMasterRemoved && isChildToMasterRemovedFilter == null)
            {
                masterData.Remove(key);
            }

            childData.TryRemove(key, out TValue rsltvalue);
            if (rsltvalue != null)
                ChangedRemoved?.Invoke(key, value);
            return rsltvalue;
        }
        #endregion

        #region Changed
        public event Action<TKey, TValue> ChangedAdded;
        public event Action<TKey, TValue> ChangedUpdated;
        public event Action<TKey, TValue> ChangedRemoved;
        #endregion

        #region MasterToChild and ChildToMaster
        private bool isMasterToChildAdded;
        public bool IsMasterToChildAdded { get => isMasterToChildAdded; set => isMasterToChildAdded = value; }
        private Func<TValue, bool> isMasterToChildAddedFilter;
        public Func<TValue, bool> IsMasterToChildAddedFilter { get => isMasterToChildAddedFilter; set => isMasterToChildAddedFilter = value; }



        private bool isMasterToChildUpdated;
        public bool IsMasterToChildUpdated { get => isMasterToChildUpdated; set => isMasterToChildUpdated = value; }
        private Func<TValue, bool> isMasterToChildUpdatedFilter;
        public Func<TValue, bool> IsMasterToChildUpdatedFilter { get => isMasterToChildUpdatedFilter; set => isMasterToChildUpdatedFilter = value; }



        private bool isMasterToChildRemoved;
        public bool IsMasterToChildRemoved { get => isMasterToChildRemoved; set => isMasterToChildRemoved = value; }
        private Func<TValue, bool> isMasterToChildRemovedFilter;
        public Func<TValue, bool> IsMasterToChildRemovedFilter { get => isMasterToChildRemovedFilter; set => isMasterToChildRemovedFilter = value; }



        private void MasterData_ChangedAdded(TKey key, TValue value)
        {
            if (isMasterToChildAdded && isMasterToChildAddedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isMasterToChildAddedFilter) != null)
                {
                    var rslt = childData.TryAdd(key, value);
                    if (rslt)
                        ChangedAdded?.Invoke(key, value);
                }
            }
            else if (isMasterToChildAdded && isMasterToChildAddedFilter == null)
            {
                var rslt = childData.TryAdd(key, value);
                if (rslt)
                    ChangedAdded?.Invoke(key, value);
            }
        }

        private void MasterData_ChangedUpdated(TKey key, TValue value)
        {
            if (isMasterToChildUpdated && isMasterToChildUpdatedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isMasterToChildUpdatedFilter) != null)
                {
                    var rslt = childData.TryUpdate(key, value, value);
                    if (rslt)
                        ChangedUpdated?.Invoke(key, value);
                }
            }
            else if (isMasterToChildUpdated && isMasterToChildUpdatedFilter == null)
            {
                var rslt = childData.TryUpdate(key, value, value);
                if (rslt)
                    ChangedUpdated?.Invoke(key, value);
            }
        }

        private void MasterData_ChangedRemoved(TKey key, TValue value)
        {
            if (isMasterToChildRemoved && isMasterToChildRemovedFilter != null)
            {
                var newMasteraData = new ConcurrentDictionary<TKey, TValue>();
                newMasteraData.TryAdd(key, value);

                if (newMasteraData.Values.FirstOrDefault(isMasterToChildRemovedFilter) != null)
                {
                    childData.TryRemove(key, out TValue outvalue);
                    if (outvalue != null)
                        ChangedRemoved?.Invoke(key, outvalue);
                }
            }
            else if (isMasterToChildRemoved && isMasterToChildRemovedFilter != null)
            {
                childData.TryRemove(key, out TValue outvalue);
                if (outvalue != null)
                    ChangedRemoved?.Invoke(key, outvalue);
            }
        }


        private bool isChildToMasterAdded;
        public bool IsChildToMasterAdded { get => isChildToMasterAdded; set => isChildToMasterAdded = value; }
        private Func<TValue, bool> isChildToMasterAddedFilter;
        public Func<TValue, bool> IsChildToMasterAddedFilter { get => isChildToMasterAddedFilter; set => isChildToMasterAddedFilter = value; }


        private bool isChildToMasterUpdated;
        public bool IsChildToMasterUpdated { get => isChildToMasterUpdated; set => isChildToMasterUpdated = value; }
        private Func<TValue, bool> isChildToMasterUpdatedFilter;
        public Func<TValue, bool> IsChildToMasterUpdatedFilter { get => isChildToMasterUpdatedFilter; set => isChildToMasterUpdatedFilter = value; }


        private bool isChildToMasterRemoved;
        public bool IsChildToMasterRemoved { get => isChildToMasterRemoved; set => isChildToMasterRemoved = value; }
        private Func<TValue, bool> isChildToMasterRemovedFilter;
        public Func<TValue, bool> IsChildToMasterRemovedFilter { get => isChildToMasterRemovedFilter; set => isChildToMasterRemovedFilter = value; }
        #endregion
    }
}
