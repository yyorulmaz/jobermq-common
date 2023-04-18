using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Multiple
{
    //public class MultipleMessageModel : MultipleMethodModelBase
    //{
    //    public string Message { get; set; }
    //}

    public class MultipleMessageModel
    {
        public MessageModel Message { get; set; }
        public bool IsResult { get; set; }
        public MessageModel ResultMessage { get; set; }
  

    }
}
