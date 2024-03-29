﻿using System.Collections.Generic;

namespace JoberMQ.Library.Method.Models
{
    public class MethodPropertyModel
    {
        public string MethodAssemblyName { get; set; }
        public string MethodNamespaceName { get; set; }
        public string MethodClassName { get; set; }
        public string MethodName { get; set; }
        public List<MethodParameterModel> ParemeterValues { get; set; }
        public bool IsChildClass { get; set; }
    }
}
