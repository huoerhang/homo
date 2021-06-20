using Microsoft.Extensions.Logging;

namespace Homo
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
