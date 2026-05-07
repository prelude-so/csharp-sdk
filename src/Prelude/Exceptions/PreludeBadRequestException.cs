using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeBadRequestException : Prelude4xxException
{
    public PreludeBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
