using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Abstraction.Text;
using System;
using System.Collections.Generic;

namespace JoberMQ.Library.Database.Repository.Abstraction.Opr
{
    public interface IOprRepositoryGuid<TValue>
    where TValue : DboPropertyGuidBase, new()
    {
        IMemRepository<Guid, TValue> DbMem { get; set; }
        ITextRepository<TValue> DbText { get; set; }


        #region CRUD
        TValue Get(Guid id);
        TValue Get(Func<TValue, bool> filter = null);
        List<TValue> GetAll(Func<TValue, bool> filter = null);
        bool Add(Guid key, TValue dbo);
        bool Update(Guid key, TValue dbo);
        bool Delete(Guid key, TValue dbo);

        bool Commit(Guid key, TValue dbo);
        bool Rollback(Guid key, TValue dbo);
        #endregion

        #region Changed
        event Action<TValue> ChangedAdded;
        event Action<TValue> ChangedUpdated;
        event Action<TValue> ChangedRemoved;
        #endregion

        void Setups();
        void CreateFolder();
        void DataGroupingAndSize();
        void CreateStream();
        void ImportTextDataToSetMemDb();

        int ArsiveFileCounter { get; set; }
    }
}
