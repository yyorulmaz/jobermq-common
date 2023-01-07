using JoberMQ.Library.Database.Enums;
using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.Database.Repository.Implementation.Mem.Default;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Database.Factories
{
    public class MemChildFactory
    {
        public static IMemChildGeneralRepository<TKey, TValue> CreateChildGeneral<TKey, TValue>(
            MemChildFactoryEnum memChildFactoryEnum,
            IMemRepository<TKey, TValue> master,
            bool isMasterDataActiviteAdded = false, 
            bool isMasterDataActiviteUpdated = false, 
            bool isMasterDataActiviteRemoved = false)
        {
            IMemChildGeneralRepository<TKey, TValue> memChildGeneralRepository;

            switch (memChildFactoryEnum)
            {
                case MemChildFactoryEnum.Default:
                    memChildGeneralRepository = new DfMemChildGeneralRepository<TKey, TValue>(master, isMasterDataActiviteAdded, isMasterDataActiviteUpdated, isMasterDataActiviteRemoved);
                    break;
                default:
                    memChildGeneralRepository = new DfMemChildGeneralRepository<TKey, TValue>(master, isMasterDataActiviteAdded, isMasterDataActiviteUpdated, isMasterDataActiviteRemoved);
                    break;
            }

            return memChildGeneralRepository;
        }

        public static IMemChildFIFORepository<TKey, TValue> CreateChildFIFO<TKey, TValue>(
            MemChildFactoryEnum memChildFactoryEnum,
            IMemRepository<TKey, TValue> master)
        {
            IMemChildFIFORepository<TKey, TValue> memChildFIFORepository;

            switch (memChildFactoryEnum)
            {
                case MemChildFactoryEnum.Default:
                    memChildFIFORepository = new DfMemChildFIFORepository<TKey, TValue>(master);
                    break;
                default:
                    memChildFIFORepository = new DfMemChildFIFORepository<TKey, TValue>(master);
                    break;
            }

            return memChildFIFORepository;
        }

        public static IMemChildLIFORepository<TKey, TValue> CreateChildLIFO<TKey, TValue>(
            MemChildFactoryEnum memChildFactoryEnum,
            IMemRepository<TKey, TValue> master)
        {
            IMemChildLIFORepository<TKey, TValue> memChildLIFORepository;

            switch (memChildFactoryEnum)
            {
                case MemChildFactoryEnum.Default:
                    memChildLIFORepository = new DfMemChildLIFORepository<TKey, TValue>(master);
                    break;
                default:
                    memChildLIFORepository = new DfMemChildLIFORepository<TKey, TValue>(master);
                    break;
            }

            return memChildLIFORepository;
        }
    }
}
