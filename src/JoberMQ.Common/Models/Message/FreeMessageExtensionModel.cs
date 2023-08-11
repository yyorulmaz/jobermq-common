using JoberMQ.Common.Dbos;

namespace JoberMQ.Common.Models.Message
{
    public class FreeMessageClientExtensionModel<T>
    {
        public T Client { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }
        
    }
    public class FreeMessageGroupExtensionModel<T>
    {
        public T Client { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }

    }
}
