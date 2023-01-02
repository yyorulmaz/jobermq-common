using JoberMQ.Library.RoundRobin.Abstraction;
using JoberMQ.Library.RoundRobin.Enums;
using JoberMQ.Library.RoundRobin.Implementation.Default;

namespace JoberMQ.Library.RoundRobin.Factories
{
    internal class RoundRobinFactory
    {
        internal static IRoundRobin<T> Create<T>(RoundRobinFactoryEnum factory)
        {
            IRoundRobin<T> roundRobin;

            switch (factory)
            {
                case RoundRobinFactoryEnum.Default:
                    roundRobin = new DfRoundRobin<T>();
                    break;
                default:
                    roundRobin = new DfRoundRobin<T>();
                    break;
            }

            return roundRobin;
        }
    }
}
