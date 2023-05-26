using JoberMQ.Common.StatusCode.Enums;

namespace JoberMQ.Common.StatusCode.Abstraction
{
    public interface IStatusCode
    {
        string GetStatusMessage(string statusCode);
        string GetStatusMessage(string statusCode, StatusCodeMessageLanguageEnum language);
    }
}
