using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Factories;
using JoberMQ.Library.Database.Helper;
using JoberMQ.Library.Database.Models;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Abstraction.Opr;
using JoberMQ.Library.Database.Repository.Abstraction.Text;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;

namespace JoberMQ.Library.Database.Repository.Implementation.Opr.Default
{
    public class DfOprRepository<TKey, TValue> : IOprRepository<TKey, TValue>
        where TValue : DboPropertyGuidBase, new()
    {
        //public DfOprRepository(
        //    IMemRepository<TKey, TValue> dbMem,
        //    ITextRepository<TValue> dbText)
        //{
        //    this.dbMem = dbMem;
        //    this.dbText = dbText;
        //}

        public DfOprRepository(MemFactoryEnum memFactory, MemDataFactoryEnum memDataFactory, ConcurrentDictionary<TKey, TValue> memMasterData, TextFactoryEnum textFactory, TextFileConfigModel textFileConfig)
        {
            this.dbMem = MemFactory.Create<TKey, TValue>(memFactory, memDataFactory, memMasterData);
            this.dbText = TextFactory.Create<TValue>(textFactory, textFileConfig);
        }

        private IMemRepository<TKey, TValue> dbMem;
        public IMemRepository<TKey, TValue> DbMem { get => dbMem; set => dbMem = value; }
        private ITextRepository<TValue> dbText;
        public ITextRepository<TValue> DbText { get => dbText; set => dbText = value; }

        #region CRUD
        public TValue Get(TKey id) => dbMem.Get(id);
        public List<TValue> GetAll(Func<TValue, bool> filter = null) => dbMem.GetAll(filter);
        public virtual bool Add(TKey key, TValue dbo)
        {
            var processTime = DateHelper.GetUniversalNow();
            dbo.CreateDate = processTime;
            dbo.DataStatusType = DataStatusTypeEnum.Insert;
            dbo.ProcessTime = processTime;

            if (dbo.IsDbTextSave)
                dbText.WriteLine(dbo);
            dbMem.Add(key, dbo);
            ChangedAdded?.Invoke(dbo);

            return true;
        }
        public virtual bool Update(TKey key, TValue dbo)
        {
            var processTime = DateHelper.GetUniversalNow();
            dbo.UpdateDate = processTime;
            dbo.DataStatusType = DataStatusTypeEnum.Update;
            dbo.ProcessTime = processTime;

            if (dbo.IsDbTextSave)
                dbText.WriteLine(dbo);
            dbMem.Update(key, dbo);
            ChangedUpdated?.Invoke(dbo);

            return true;
        }
        public virtual bool Delete(TKey key, TValue dbo)
        {
            var processTime = DateHelper.GetUniversalNow();
            dbo.DataStatusType = DataStatusTypeEnum.Delete;
            dbo.ProcessTime = processTime;

            if (dbo.IsDbTextSave)
                dbText.WriteLine(dbo);
            dbMem.Remove(key);
            ChangedRemoved?.Invoke(dbo);

            return true;
        }

        public bool Commit(TKey key, TValue dbo)
        {
            dbo.IsTransactionCompleted = true;
            dbo.TransactionDate = DateHelper.GetUniversalNow();

            return Add(key, dbo);
        }
        public bool Rollback(TKey key, TValue dbo)
        {
            dbo.IsTransactionCompleted = false;
            dbo.TransactionDate = DateHelper.GetUniversalNow();

            return Delete(key, dbo);
        }
        #endregion

        #region Changed
        public event Action<TValue> ChangedAdded;
        public event Action<TValue> ChangedUpdated;
        public event Action<TValue> ChangedRemoved;
        #endregion

        public void Setups()
        {
            CreateFolder();
            DataGroupingAndSize();
            //ImportTextDataToSetMemDb();
            CreateStream();
        }

        public void CreateFolder()
            => dbText.CreateFolder();
        public void DataGroupingAndSize()
           => dbText.DataGroupingAndSize();
        public void CreateStream()
            => dbText.CreateStream();



        //public void ImportTextDataToSetMemDb()
        //{
        //    var datas = dbText.ReadAllDataGrouping(true);

        //    if (datas != null)
        //        foreach (var data in datas)
        //            dbMem.Add(data.Id, data);



        //    //return true;
        //}

        public int ArsiveFileCounter { get => dbText.ArsiveFileCounter; set => dbText.ArsiveFileCounter = value; }
    }
}
