using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeForbiddenException : Prelude4xxException
{
    public PreludeForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
