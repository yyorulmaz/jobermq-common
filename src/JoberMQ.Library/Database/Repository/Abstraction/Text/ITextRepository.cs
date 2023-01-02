using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JoberMQ.Library.Database.Repository.Abstraction.Text
{
    internal interface ITextRepository<T> where T : DboPropertyGuidBase, new()
    {
        #region Create Folder
        bool CreateFolder();
        #endregion

        #region DataGroupingAndSize
        bool DataGroupingAndSize();
        #endregion

        #region Setup
        bool Setup();
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
