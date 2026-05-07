using System;

namespace Prelude.Exceptions;

public class PreludeInvalidDataException : PreludeException
{
    public PreludeInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
