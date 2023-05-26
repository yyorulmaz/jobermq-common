using System;
using JoberMQ.Common.Models.Base;

namespace JoberMQ.Common.Models.Response
{
    public class ResponseModel : ResponseBaseModel
    {
        public ResponseModel()
        {
            IsOnline = false;
            IsSucces = false;
            Message = null;
            Id = null;
            IsQueue = true;
        }
        public Guid? Id { get; set; }
        public bool IsQueue { get; set; }
    }
}
