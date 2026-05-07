using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeRateLimitException : Prelude4xxException
{
    public PreludeRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
