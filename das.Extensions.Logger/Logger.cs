using das.Extensions.Logger.Abstractions;
using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger
{
    public class Logger : ILogger
    {
        private readonly string _source;
        private readonly LoggerProvider _provider;

        internal Logger(string source, LoggerProvider provider)
        {
            _source = source;
            _provider = provider;
        }

        public ILogScope BeginScope(string scope)
        {
            return new LogScope(this, scope);
        }

        internal static Logger Log(string source, LoggerProvider writers)
        {
            return new Logger(source, writers);
        }

        internal void WriteEvent(LogEvent logEvent)
        {
            foreach (ILogWriter writer in _provider.Writers)
            {
                if (writer.IsEnabled(logEvent)) writer.WriteEvent(logEvent);
            }
        }

        public void Info(string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Info, _source, message));
        }

        public void Warn(string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Warning, _source, message));
        }

        public void Debug(string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Debug, _source, message));
        }

        public void Error(string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Error, _source, message));
        }

        public void InfoIf(bool condition, string message)
        {
            if (condition) Info(message);
        }

        public void WarnIf(bool condition, string message)
        {
            if (condition) Warn(message);
        }

        public void DebugIf(bool condition, string message)
        {
            if (condition) Debug(message);
        }

        public void ErrorIf(bool condition, string message)
        {
            if (condition) Error(message);
        }
    }
}
