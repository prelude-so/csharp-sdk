using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class Prelude4xxException : PreludeApiException
{
    public Prelude4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
