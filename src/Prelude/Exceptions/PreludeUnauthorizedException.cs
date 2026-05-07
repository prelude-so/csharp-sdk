using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeUnauthorizedException : Prelude4xxException
{
    public PreludeUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
