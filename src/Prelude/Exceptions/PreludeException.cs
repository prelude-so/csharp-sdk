using System;
using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeException : Exception
{
    public PreludeException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected PreludeException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
