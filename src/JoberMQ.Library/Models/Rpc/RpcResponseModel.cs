using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Library.Models.Rpc
{
    public class RpcResponseModel
    {
        public Guid Id { get; set; }
        public string Result { get; set; }
    }
}
