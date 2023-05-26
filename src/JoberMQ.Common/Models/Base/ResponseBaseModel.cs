namespace JoberMQ.Common.Models.Base
{
    public class ResponseBaseModel
    {
        public bool IsOnline { get; set; }
        public bool IsSucces { get; set; }
        public string Message { get; set; }
    }
    public class ResponseBaseModel<T>
    {
        public bool IsOnline { get; set; }
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
