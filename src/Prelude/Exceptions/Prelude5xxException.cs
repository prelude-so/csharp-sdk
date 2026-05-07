using System.Net.Http;

namespace Prelude.Exceptions;

public class Prelude5xxException : PreludeApiException
{
    public Prelude5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
