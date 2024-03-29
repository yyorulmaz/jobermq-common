﻿using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Abstraction.Text;
using System;
using System.Collections.Generic;

namespace JoberMQ.Library.Database.Repository.Abstraction.Opr
{
    public interface IOprRepository<TKey, TValue>
    where TValue : DboPropertyGuidBase, new()
    {
        IMemRepository<TKey, TValue> DbMem { get; set; }
        ITextRepository<TValue> DbText { get; set; }


        #region CRUD
        TValue Get(TKey id);
        List<TValue> GetAll(Func<TValue, bool> filter = null);
        bool Add(TKey key, TValue dbo);
        bool Update(TKey key, TValue dbo);
        bool Delete(TKey key, TValue dbo);

        bool Commit(TKey key, TValue dbo);
        bool Rollback(TKey key, TValue dbo);
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
        //void ImportTextDataToSetMemDb();

        int ArsiveFileCounter { get; set; }
    }
}
