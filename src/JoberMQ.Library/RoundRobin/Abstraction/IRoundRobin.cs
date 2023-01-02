using JoberMQ.Library.RoundRobin.Models;
using System;
using System.Collections.Generic;

namespace JoberMQ.Library.RoundRobin.Abstraction
{
    public interface IRoundRobin<T>
    {
        RoundRobinModel<T> Get(Guid id);
        List<RoundRobinModel<T>> GetAll();
        RoundRobinModel<T> GetEndRoundRobin();
        T GetEndRoundRobinData();
        RoundRobinModel<T> Add(T value, int weight);
        RoundRobinModel<T> Remove(Guid id);
        T Next { get; }
    }
}
