using System.Net.Http;

namespace Prelude.Exceptions;

public class Prelude4xxException : PreludeApiException
{
    public Prelude4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
