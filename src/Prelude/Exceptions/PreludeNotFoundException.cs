using System.Net.Http;

namespace Prelude.Exceptions;

public class PreludeNotFoundException : Prelude4xxException
{
    public PreludeNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
