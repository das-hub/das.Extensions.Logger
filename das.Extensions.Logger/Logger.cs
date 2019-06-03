using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Info(string source, string message);
        void Warn(string source, string message);
        void Debug(string source, string message);
        void Error(string source, string message);

        void InfoIf(bool condition, string message);
        void WarnIf(bool condition, string message);
        void DebugIf(bool condition, string message);
        void ErrorIf(bool condition, string message);
        void InfoIf(bool condition, string source, string message);
        void WarnIf(bool condition, string source, string message);
        void DebugIf(bool condition, string source, string message);
        void ErrorIf(bool condition, string source, string message);
    }

    internal class Logger : ILogger
    {
        private readonly string _source;
        private readonly LoggerProvider _provider;

        internal Logger(string source, LoggerProvider provider)
        {
            _source = source;
            _provider = provider;
        }

        internal static Logger Log(string source, LoggerProvider writers)
        {
            return new Logger(source, writers);
        }

        internal void WriteEvent(LogEvent logEvent)
        {
            foreach (LogWriter writer in _provider.Writers)
            {
                writer.WriteEvent(logEvent);
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

        public void Info(string source, string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Info, $"{_source} => {source}", message));
        }

        public void Warn(string source, string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Warning, $"{_source} => {source}", message));
        }

        public void Debug(string source, string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Debug, $"{_source} => {source}", message));
        }

        public void Error(string source, string message)
        {
            WriteEvent(LogEvent.Create(LogLevel.Error, $"{_source} => {source}", message));
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

        public void InfoIf(bool condition, string source, string message)
        {
            if (condition) Info(source, message);
        }

        public void WarnIf(bool condition, string source, string message)
        {
            if (condition) Warn(source, message);
        }

        public void DebugIf(bool condition, string source, string message)
        {
            if (condition) Debug(source, message);
        }

        public void ErrorIf(bool condition, string source, string message)
        {
            if (condition) Error(source, message);
        }
    }
}
