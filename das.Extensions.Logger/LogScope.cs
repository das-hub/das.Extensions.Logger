using System;

namespace das.Extensions.Logger
{
    public class LogScope : ILogger, IDisposable
    {
        private readonly string _source;
        private readonly Logger _logger;

        internal LogScope(string source, Logger logger, string scope)
        {
            _source = $"{source}:[{scope}]";
            _logger = logger;
            _logger.Info($" Группа событий ({_source}) - запущена");
        }

        public void Info(string message)
        {
            _logger.WriteEvent(LogEvent.Create(LogLevel.Info, _source, message));
        }

        public void Warn(string message)
        {
            _logger.WriteEvent(LogEvent.Create(LogLevel.Warning, _source, message));
        }

        public void Debug(string message)
        {
            _logger.WriteEvent(LogEvent.Create(LogLevel.Debug, _source, message));
        }

        public void Error(string message)
        {
            _logger.WriteEvent(LogEvent.Create(LogLevel.Error, _source, message));
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

        LogScope ILogger.BeginScope(string scope)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _logger.Info($" Группа событий ({_source}) - завершена");
        }
    }
}
