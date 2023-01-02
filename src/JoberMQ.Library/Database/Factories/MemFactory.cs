using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Implementation.Mem.Default;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Factories
{
    internal class MemFactory
    {
        internal static IMemRepository<TKey, TValue> CreateMem<TKey, TValue>(MemFactoryEnum memFactory, MemDataFactoryEnum memDataFactory, ConcurrentDictionary<TKey, TValue> masterData)
        {
            IMemRepository<TKey, TValue> memRepository;

            switch (memFactory)
            {
                case MemFactoryEnum.Default:
                    switch (memDataFactory)
                    {
                        case MemDataFactoryEnum.Data:
                            memRepository = new DfMemRepository<TKey, TValue>(masterData);
                            break;
                        default:
                            memRepository = new DfMemRepository<TKey, TValue>(masterData);
                            break;
                    }
                    break;
                default:
                    switch (memDataFactory)
                    {
                        case MemDataFactoryEnum.Data:
                            memRepository = new DfMemRepository<TKey, TValue>(masterData);
                            break;
                        default:
                            memRepository = new DfMemRepository<TKey, TValue>(masterData);
                            break;
                    }
                    break;
            }

            return memRepository;
        }
    }
}
