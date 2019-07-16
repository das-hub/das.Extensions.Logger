namespace das.Extensions.Logger.Abstractions
{
    public interface ILogWriter
    {
        bool IsEnabled(LogEvent logEvent);
        void WriteEvent(LogEvent logEvent);
    }
}