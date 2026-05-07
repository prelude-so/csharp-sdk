using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeBadRequestException : Prelude4xxException
{
    public PreludeBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
