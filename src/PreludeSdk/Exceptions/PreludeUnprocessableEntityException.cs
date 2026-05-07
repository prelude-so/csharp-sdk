using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeUnprocessableEntityException : Prelude4xxException
{
    public PreludeUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
