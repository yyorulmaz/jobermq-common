using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JoberMQ.Common.Database.Base;
using JoberMQ.Common.Database.Models;

namespace JoberMQ.Common.Database.Repository.Abstraction.Text
{
    public interface ITextRepository<T> where T : DboPropertyGuidBase, new()
    {
        #region Create Folder
        void CreateFolder();
        #endregion

        #region DataGroupingAndSize
        void DataGroupingAndSize();
        #endregion

        #region Create Stream
        void CreateStream();
        #endregion

        #region Write
        bool WriteLine(string message);
        bool WriteLine(T message);
        #endregion

        #region Read
        List<T> ReadAllData(bool isFullFileList);
        (List<T> datas, List<DataLogFileModel> paths) ReadAllData2(bool isFullFileList);
        List<T> ReadAllDataGrouping(bool isFullFileList);
        (List<T> datas, List<DataLogFileModel> paths) ReadAllDataGrouping2(bool isFullFileList);
        #endregion

        #region FileStream StreamWriter
        FileStream FileStreamCreate(string pathFull, int? bufferSize);
        StreamWriter StreamWriterCreate(FileStream fileStream);
        #endregion

        #region Path
        string GetBaseFileFullPath();
        string GetArsiveFileFullPath(int fileNumber);
        #endregion

        #region Arsive File
        int ArsiveFileCounter { get; set; }
        #endregion
    }
}
