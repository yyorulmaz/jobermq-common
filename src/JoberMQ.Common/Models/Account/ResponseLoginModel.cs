using System;
using System.Collections.Generic;
using System.Text;

namespace JoberMQ.Common.Models.Account
{
    public class ResponseLoginModel
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }
}
