using JoberMQ.Common.Database.Enums;
using JoberMQ.Common.Database.Repository.Abstraction.Mem;
using JoberMQ.Common.Database.Repository.Implementation.Mem.Default;
using System;
using System.Collections.Concurrent;

namespace JoberMQ.Common.Database.Factories
{
    public class MemFactory
    {
        public static IMemRepository<TKey, TValue> Create<TKey, TValue>(MemFactoryEnum memFactory, MemDataFactoryEnum memDataFactory, ConcurrentDictionary<TKey, TValue> masterData = null)
        {
            if (memDataFactory == MemDataFactoryEnum.Data && masterData == null)
                throw new ArgumentNullException("masterData null");


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
