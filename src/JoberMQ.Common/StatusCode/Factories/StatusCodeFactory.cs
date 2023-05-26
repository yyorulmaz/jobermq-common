using JoberMQ.Common.StatusCode.Abstraction;
using JoberMQ.Common.StatusCode.Enums;
using JoberMQ.Common.StatusCode.Implementation.Default;
using JoberMQ.Common.StatusCode.Models;
using System.Collections.Concurrent;

namespace JoberMQ.Common.StatusCode.Factories
{
    public class StatusCodeFactory
    {
        public static IStatusCode Create(StatusCodeFactoryEnum factory, ConcurrentDictionary<string, StatusCodeModel> statusCodeData, StatusCodeMessageLanguageEnum defaultStatusCodeMessageLanguage)
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
