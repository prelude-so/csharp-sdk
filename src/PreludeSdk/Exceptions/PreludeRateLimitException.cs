using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeRateLimitException : Prelude4xxException
{
    public PreludeRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
