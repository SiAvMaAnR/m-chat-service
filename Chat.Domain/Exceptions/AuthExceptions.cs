using Chat.Domain.Exceptions.Common;

namespace Chat.Domain.Exceptions;

public class FailedToCreatePasswordException : BusinessException
{
    public FailedToCreatePasswordException()
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.InternalServer,
                BusinessStatusCode = BusinessStatusCode.AuthE001,
                SystemMessage = $"Failed to create password",
                ClientMessage = $"Failed to create password"
            }
        )
    { }
}

public class InvalidConfirmationException : BusinessException
{
    public InvalidConfirmationException()
        : base(
            new ExceptionArgs()
            {
                ApiStatusCode = ApiStatusCode.Forbidden,
                BusinessStatusCode = BusinessStatusCode.AuthE002,
                SystemMessage = $"Invalid confirmation link",
                ClientMessage = $"Invalid confirmation link"
            }
        )
    { }
}

