using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeUnprocessableEntityException : Prelude4xxException
{
    public PreludeUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
