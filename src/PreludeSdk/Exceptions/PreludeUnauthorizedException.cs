using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeUnauthorizedException : Prelude4xxException
{
    public PreludeUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
