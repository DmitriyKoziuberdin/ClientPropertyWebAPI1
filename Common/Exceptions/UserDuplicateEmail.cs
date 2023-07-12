using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class UserDuplicateEmail : BusinessLogicExceptionBase
    {
        public UserDuplicateEmail(string message) : base(message)
        {
            ErrorCode = ErrorCodes.UserDuplicateEmail;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
