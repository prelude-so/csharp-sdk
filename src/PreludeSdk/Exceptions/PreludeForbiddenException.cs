using System.Net.Http;

namespace PreludeSdk.Exceptions;

public class PreludeForbiddenException : Prelude4xxException
{
    public PreludeForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
