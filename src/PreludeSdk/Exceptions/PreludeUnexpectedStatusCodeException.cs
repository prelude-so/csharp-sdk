using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeUnexpectedStatusCodeException : PreludeApiException
{
    public PreludeUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
