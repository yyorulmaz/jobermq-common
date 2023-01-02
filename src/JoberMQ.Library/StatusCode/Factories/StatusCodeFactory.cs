using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.StatusCode.Abstraction;
using JoberMQ.Library.StatusCode.Enums;
using JoberMQ.Library.StatusCode.Implementation.Default;
using JoberMQ.Library.StatusCode.Models;
using System.Collections.Concurrent;

namespace JoberMQ.Library.StatusCode.Factories
{
    internal class StatusCodeFactory
    {
        internal static IStatusCode Create(StatusCodeFactoryEnum factory, ConcurrentDictionary<string, StatusCodeModel> statusCodeData, StatusCodeMessageLanguageEnum defaultStatusCodeMessageLanguage)
        {
            IStatusCode statusCode;

            switch (factory)
            {
                case StatusCodeFactoryEnum.Default:
                    statusCode = new DfStatusCode(statusCodeData, defaultStatusCodeMessageLanguage);
                    break;
                default:
                    statusCode = new DfStatusCode(statusCodeData, defaultStatusCodeMessageLanguage);
                    break;
            }

            return statusCode;
        }
    }
}
