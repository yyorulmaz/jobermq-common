using JoberMQ.Common.Method.Abstraction;
using JoberMQ.Common.Method.Enums;
using JoberMQ.Common.Method.Implementation.Default;

namespace JoberMQ.Common.Method.Factories
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
