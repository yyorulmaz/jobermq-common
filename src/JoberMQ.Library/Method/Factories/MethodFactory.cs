using JoberMQ.Library.Method.Abstraction;
using JoberMQ.Library.Method.Implementation.Default;
using JoberMQ.Library.StatusCode.Abstraction;
using JoberMQ.Library.StatusCode.Enums;
using JoberMQ.Library.StatusCode.Implementation.Default;
using JoberMQ.Library.StatusCode.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Method.Factories
{
    public class MethodFactory
    {
        public static IMethod Create(StatusCodeFactoryEnum factory, ConcurrentDictionary<string, StatusCodeModel> statusCodeData, StatusCodeMessageLanguageEnum defaultStatusCodeMessageLanguage)
        {
            IMethod method;

            switch (factory)
            {
                case StatusCodeFactoryEnum.Default:
                    method = new DfMethod();
                    break;
                default:
                    method = new DfMethod();
                    break;
            }

            return method;
        }
    }
}
