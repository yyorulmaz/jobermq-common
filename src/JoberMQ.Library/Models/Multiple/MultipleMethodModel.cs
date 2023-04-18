using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JoberMQ.Library.Models.Multiple
{
    public class MultipleMethodModel : MultipleMethodModelBase
    {
        public Expression<Action> MethodCall { get; set; }
    }
}
