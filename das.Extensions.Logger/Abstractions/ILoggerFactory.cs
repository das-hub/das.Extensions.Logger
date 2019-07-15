namespace das.Extensions.Logger.Abstractions
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string source = null, LoggerProvider provider = null);
        ILogger ReconfigureLogger(string source, LoggerProvider provider);
    }
}