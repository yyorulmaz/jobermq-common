using System;

namespace JoberMQ.Common.Models.Rpc
{
    public class RpcResponseModel
    {
        public Guid Id { get; set; }
        //public string ResultData { get; set; }
        public byte[] ResultData { get; set; }
        
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class RpcResponseModel<T>
    {
        public Guid Id { get; set; }
        public T ResultData { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
