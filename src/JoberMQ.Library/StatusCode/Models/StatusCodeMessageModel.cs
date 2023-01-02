using JoberMQ.Library.StatusCode.Enums;

namespace JoberMQ.Library.StatusCode.Models
{
    public class StatusCodeMessageModel
    {
        public StatusCodeMessageLanguageEnum Language { get; set; }
        public string Message { get; set; }
    }
}
