using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Factories;
using JoberMQ.Library.Database.Models;
using JoberMQ.Library.Database.Repository.Abstraction.Opr;
using JoberMQ.Library.Database.Repository.Implementation.Opr.Default;
using System.Collections.Concurrent;

  ConcurrentDictionary<Guid, DistributorDbo> DistributorDatas = new ConcurrentDictionary<Guid, DistributorDbo>();

var SETT = new TextFileConfigModel
{
    DbPath = "Database",
    DbFolderPath = "Distributor",
    DbFileName = "Distributor",
    DbFileSeparator = '.',
    DbArchiveFileSeparator = '_',
    DbFileExtension = "txt",
    MaxRowCount = 100000
};

var oprt = OprFactory.Create(OprFactoryEnum.Default,MemFactoryEnum.Default, MemDataFactoryEnum.Data, DistributorDatas, TextFactoryEnum.Default, SETT);

oprt.Setups();

Console.WriteLine("Hello, World!");





internal interface IDistributorDbOpr : IOprRepository<Guid, DistributorDbo>
{
}

internal class DistributorDbo : DboPropertyGuidBase, IDboBase
{
    //[JsonProperty("1")]
    public string DistributorKey { get; set; }
    public bool IsDurable { get; set; }
}

internal class DfDistributorDbOpr : DfOprRepository<Guid, DistributorDbo>, IDistributorDbOpr
{
    public DfDistributorDbOpr(MemFactoryEnum memFactory, MemDataFactoryEnum memDataFactory, ConcurrentDictionary<Guid, DistributorDbo> memMasterData, TextFactoryEnum textFactory, TextFileConfigModel textFileConfig) : base(memFactory, memDataFactory, memMasterData, textFactory, textFileConfig)
    {
    }

}