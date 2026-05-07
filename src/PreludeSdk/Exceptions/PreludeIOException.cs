using System;
using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeIOException : PreludeException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public PreludeIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
