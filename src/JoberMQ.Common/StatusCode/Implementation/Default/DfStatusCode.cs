using System;
using System.Collections.Concurrent;
using System.Linq;
using JoberMQ.Common.Database.Factories;
using JoberMQ.Common.Database.Repository.Abstraction.Mem;
using JoberMQ.Common.StatusCode.Abstraction;
using JoberMQ.Common.StatusCode.Enums;
using JoberMQ.Common.StatusCode.Models;

namespace JoberMQ.Common.StatusCode.Implementation.Default
{
    public class DfStatusCode : IStatusCode
    {
        private readonly IMemRepository<string, StatusCodeModel> memRepo;
        private readonly StatusCodeMessageLanguageEnum statusCodeMessageLanguage;
        public DfStatusCode(ConcurrentDictionary<string, StatusCodeModel> statusCodeData, StatusCodeMessageLanguageEnum defaultStatusCodeMessageLanguage)
        {

            /* Unmerged change from project 'JoberMQ.Common (netstandard2.0)'
            Before:
                        memRepo = MemFactory.Create<string, StatusCodeModel>(Database.Enums.MemFactoryEnum.Default, Database.Enums.MemDataFactoryEnum.Data, statusCodeData);
            After:
                        memRepo = MemFactory.Create<string, StatusCodeModel>(Database.Enums.MemFactoryEnum.Default, MemDataFactoryEnum.Data, statusCodeData);
            */

            /* Unmerged change from project 'JoberMQ.Common (netstandard2.0)'
            Before:
                        memRepo = MemFactory.Create<string, StatusCodeModel>(Database.Enums.MemFactoryEnum.Default, JoberMQ.Common.Database.Enums.MemDataFactoryEnum.Data, statusCodeData);
            After:
                        memRepo = MemFactory.Create<string, StatusCodeModel>(MemFactoryEnum.Default, JoberMQ.Common.Database.Enums.MemDataFactoryEnum.Data, statusCodeData);
            */
            memRepo = MemFactory.Create(Database.Enums.MemFactoryEnum.Default, Database.Enums.MemDataFactoryEnum.Data, statusCodeData);
            statusCodeMessageLanguage = defaultStatusCodeMessageLanguage;
        }

        public string GetStatusMessage(string statusCode) => GetStatusMessage(statusCode, statusCodeMessageLanguage);
        public string GetStatusMessage(string statusCode, StatusCodeMessageLanguageEnum language)
        {
            try
            {
                var message = memRepo.Get(statusCode).StatusCodeMessages.FirstOrDefault(x => x.Language == language).Message;
                return $"{statusCode} - {message}";
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
