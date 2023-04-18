using JoberMQ.Library.Models.Base;
using System;

namespace JoberMQ.Library.Models.Response
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
        public bool IsOnline { get; set; }
        public Guid? Id { get; set; }
        public bool IsQueue { get; set; }
    }
}
