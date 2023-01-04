using JoberMQ.Library.Database.Base;
using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Models;
using JoberMQ.Library.Database.Repository.Abstraction.Opr;
using JoberMQ.Library.Database.Repository.Implementation.Opr.Default;
using System;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Factories
{
    public class OprFactory
    {
        public static IOprRepository<TKey, TValue> Create<TKey, TValue>(
            OprFactoryEnum oprFactory,
            MemFactoryEnum memFactory, 
            MemDataFactoryEnum memDataFactory, 
            ConcurrentDictionary<TKey, TValue> memMasterData, 
            TextFactoryEnum textFactory, 
            TextFileConfigModel textFileConfig)
            where TValue : DboPropertyGuidBase, new()
        {
            IOprRepository<TKey, TValue> oprRepository;

            switch (oprFactory)
            {
                case OprFactoryEnum.Default:
                    oprRepository = new DfOprRepository<TKey, TValue>(memFactory, memDataFactory, memMasterData, textFactory, textFileConfig);
                    break;
                default:
                    oprRepository = new DfOprRepository<TKey, TValue>(memFactory, memDataFactory, memMasterData, textFactory, textFileConfig);
                    break;
            }

            return oprRepository;
        }

        public static IOprRepositoryGuid<TValue> Create<TValue>(
            OprFactoryEnum oprFactory,
            MemFactoryEnum memFactory,
            MemDataFactoryEnum memDataFactory,
            ConcurrentDictionary<Guid, TValue> memMasterData,
            TextFactoryEnum textFactory,
            TextFileConfigModel textFileConfig)
            where TValue : DboPropertyGuidBase, new()
        {
            IOprRepositoryGuid<TValue> oprRepositoryGuid;

            switch (oprFactory)
            {
                case OprFactoryEnum.Default:
                    oprRepositoryGuid = new DfOprRepositoryGuid<TValue>(memFactory, memDataFactory, memMasterData, textFactory, textFileConfig);
                    break;
                default:
                    oprRepositoryGuid = new DfOprRepositoryGuid<TValue>(memFactory, memDataFactory, memMasterData, textFactory, textFileConfig);
                    break;
            }

            return oprRepositoryGuid;
        }
    }
}
