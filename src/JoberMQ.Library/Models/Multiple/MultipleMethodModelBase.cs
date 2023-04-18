using JoberMQ.Library.Models.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Multiple
{
    public class MultipleMethodModelBase
    {
        public RoutingModel Routing { get; set; }
        public InfoModel Info { get; set; }
    }
}
