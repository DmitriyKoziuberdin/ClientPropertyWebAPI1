using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class PropertyNotFoundException : BusinessLogicExceptionBase
    {
        public PropertyNotFoundException(string message) : base(message)
        {
            ErrorCode = ErrorCodes.PropertyNotFound;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
