using Microsoft.Extensions.Logging;

namespace Delof.Logging
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
