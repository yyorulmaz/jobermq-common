using JoberMQ.Library.Method.Abstraction;
using JoberMQ.Library.Method.Enums;
using JoberMQ.Library.Method.Implementation.Default;
using JoberMQ.Library.StatusCode.Enums;

namespace JoberMQ.Library.Method.Factories
{
    public class MethodFactory
    {
        public static IMethod Create(MethodFactoryEnum factory)
        {
            IMethod method;

            switch (factory)
            {
                case MethodFactoryEnum.Default:
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
