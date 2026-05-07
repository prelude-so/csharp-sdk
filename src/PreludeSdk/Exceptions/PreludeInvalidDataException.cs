using System;

namespace PreludeSdk.Exceptions;

public class PreludeInvalidDataException : PreludeException
{
    public PreludeInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
