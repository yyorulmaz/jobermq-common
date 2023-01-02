using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Abstraction.Text;
using System;
using System.Collections.Generic;

namespace JoberMQ.Library.Database.Repository.Abstraction.Opr
{
    internal interface IOprRepository<D>
    where D : DboPropertyGuidBase, new()
    {
        IMemRepository<Guid, D> DbMem { get; set; }
        ITextRepository<D> DbText { get; set; }


        #region CRUD
        D Get(Guid id);
        List<D> GetAll(Func<D, bool> filter = null);
        bool Add(D dbo);
        bool Update(D dbo);
        bool Delete(D dbo);

        bool Commit(D dbo);
        bool Rollback(D dbo);
        #endregion

        #region Changed
        event Action<D> ChangedAdded;
        event Action<D> ChangedUpdated;
        event Action<D> ChangedRemoved;
        #endregion

        bool ImportTextDataToSetMemDb();

        bool CreateDatabase();
        bool Setup();
        bool DataGroupingAndSize();
        int ArsiveFileCounter { get; set; }
    }
}
