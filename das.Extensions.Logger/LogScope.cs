using System;

namespace das.Extensions.Logger
{
    public class LogScope : ILogger, IDisposable
    {
        private readonly Logger _logger;
        private readonly string _scope;

        internal LogScope(Logger logger, string scope)
        {
            _scope = $"{scope}";
            _logger = logger;
        }

        public void Info(string message)
        {
            _logger.Info($"{_scope} => {message}");
        }

        public void Warn(string message)
        {
            _logger.Warn($"{_scope} => {message}");
        }

        public void Debug(string message)
        {
            _logger.Debug($"{_scope} => {message}");
        }

        public void Error(string message)
        {
            _logger.Error($"{_scope} => {message}");
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

        public LogScope BeginScope(string scope)
        {
            return new LogScope(_logger, $"{_scope} => {scope}");
        }

        public void Dispose(){ }
    }
}
