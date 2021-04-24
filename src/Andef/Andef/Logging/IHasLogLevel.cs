using Microsoft.Extensions.Logging;

namespace Andef.Logging
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
