using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Implementation.Mem.Default;
using System.Collections.Concurrent;

namespace JoberMQ.Library.Database.Factories
{
    public class MemFactory
    {
        public static IMemRepository<TKey, TValue> Create<TKey, TValue>(MemFactoryEnum memFactory, MemDataFactoryEnum memDataFactory, ConcurrentDictionary<TKey, TValue> masterData = null)
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
                            memRepository = new DfMemRepository<TKey, TValue>();
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
                            memRepository = new DfMemRepository<TKey, TValue>();
                            break;
                    }
                    break;
            }

            return memRepository;
        }
    }
}
