using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeUnexpectedStatusCodeException : PreludeApiException
{
    public PreludeUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
