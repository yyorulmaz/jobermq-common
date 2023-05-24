using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Base
{
    public class ResponseBaseModel
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
    }
    public class ResponseBaseModel<T>
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
