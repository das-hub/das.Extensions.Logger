using das.Extensions.Logger.Abstractions;
using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger
{
    public class Logger : ILogger
    {
        private readonly string _source;
        private readonly LoggerProvider _provider;
        private readonly LoggerEnvironment _environment;

        internal Logger(string source, LoggerProvider provider, LoggerEnvironment environment)
        {
            _source = source;
            _provider = provider;
            _environment = environment;
        }

        public ILogScope BeginScope(string scope)
        {
            return new LogScope(this, scope);
        }

        internal static Logger Log(string source, LoggerProvider writers, LoggerEnvironment environment)
        {
            return new Logger(source, writers, environment);
        }

        internal void WriteEvent(LogEvent logEvent)
        {
            foreach (LogWriter writer in _provider.Writers)
            {
                if (writer.IsEnabled(logEvent)) writer.WriteEvent(logEvent, _environment);
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
