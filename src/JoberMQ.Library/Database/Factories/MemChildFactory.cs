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
        public static IMemChildToolsRepository<TKey, TValue> CreateChildGeneral<TKey, TValue>(
            MemChildFactoryEnum memChildFactoryEnum,
            IMemRepository<TKey, TValue> master,

            bool isMasterToChildAdded = false,
            Func<TValue, bool> isMasterToChildAddedFilter = null,

            bool isMasterToChildUpdated = false,
            Func<TValue, bool> İsMasterToChildUpdatedFilter = null,

            bool isMasterToChildRemoved = false,
            Func<TValue, bool> isMasterToChildRemovedFilter = null,

            bool isChildToMasterAdded = false,
            Func<TValue, bool> isChildToMasterAddedFilter = null,

            bool isChildToMasterUpdated = false,
            Func<TValue, bool> isChildToMasterUpdatedFilter = null,

            bool isChildToMasterRemoved = false,
            Func<TValue, bool> isChildToMasterRemovedFilter = null)
        {
            IMemChildToolsRepository<TKey, TValue> memChildToolsRepository;

            switch (memChildFactoryEnum)
            {
                case MemChildFactoryEnum.Default:
                    memChildToolsRepository = new DfMemChildToolsRepository<TKey, TValue>(
                        master,

                        isMasterToChildAdded,
                        isMasterToChildAddedFilter,

                        isMasterToChildUpdated,
                        İsMasterToChildUpdatedFilter,

                        isMasterToChildRemoved,
                        isMasterToChildRemovedFilter,

                        isChildToMasterAdded,
                        isChildToMasterAddedFilter,

                        isChildToMasterUpdated,
                        isChildToMasterUpdatedFilter,

                        isChildToMasterRemoved,
                        isChildToMasterRemovedFilter);
                    break;
                default:
                    memChildToolsRepository = new DfMemChildToolsRepository<TKey, TValue>(
                        master,

                        isMasterToChildAdded,
                        isMasterToChildAddedFilter,

                        isMasterToChildUpdated,
                        İsMasterToChildUpdatedFilter,

                        isMasterToChildRemoved,
                        isMasterToChildRemovedFilter,

                        isChildToMasterAdded,
                        isChildToMasterAddedFilter,

                        isChildToMasterUpdated,
                        isChildToMasterUpdatedFilter,

                        isChildToMasterRemoved,
                        isChildToMasterRemovedFilter);
                    break;
            }

            return memChildToolsRepository;
        }

        public static IMemChildGeneralRepository<TKey, TValue> CreateChildGeneral<TKey, TValue>(
            MemChildFactoryEnum memChildFactoryEnum,
            IMemRepository<TKey, TValue> master)
        {
            IMemChildGeneralRepository<TKey, TValue> memChildGeneralRepository;

            switch (memChildFactoryEnum)
            {
                case MemChildFactoryEnum.Default:
                    memChildGeneralRepository = new DfMemChildGeneralRepository<TKey, TValue>(master);
                    break;
                default:
                    memChildGeneralRepository = new DfMemChildGeneralRepository<TKey, TValue>(master);
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
