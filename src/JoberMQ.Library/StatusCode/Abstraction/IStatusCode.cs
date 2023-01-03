using JoberMQ.Library.Database.Repository.Abstraction.Mem;
using JoberMQ.Library.StatusCode.Enums;
using JoberMQ.Library.StatusCode.Models;

namespace JoberMQ.Library.StatusCode.Abstraction
{
    public interface IStatusCode
    {
        string GetStatusMessage(string statusCode);
        string GetStatusMessage(string statusCode, StatusCodeMessageLanguageEnum language);
    }
}
