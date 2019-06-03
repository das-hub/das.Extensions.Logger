using System;
using System.Collections.Generic;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string source = null, LogProvider provider = null);
        ILogger ReconfigureLogger(string source, LogProvider provider);
    }

    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, ILogger> _loggers = new Dictionary<string, ILogger>(StringComparer.Ordinal);
        private readonly LogProvider _defaultProvider;

        public LoggerFactory(LogProvider provider)
        {
            _defaultProvider = provider;
        }

        public static ILoggerFactory CreateFactory(LogProvider provider)
        {
            return new LoggerFactory(provider);
        }

        public ILogger CreateLogger(string source = null, LogProvider provider = null)
        {
            return AddLogger(source.ValueOrDefault(AppEnv.Name), provider ?? _defaultProvider);
        }

        public ILogger ReconfigureLogger(string source, LogProvider provider)
        {
            if (_loggers.ContainsKey(source)) _loggers.Remove(source);
            return AddLogger(source, provider);
        }

        private ILogger AddLogger(string source, LogProvider provider)
        {
            if (!_loggers.ContainsKey(source))
                _loggers.Add(source, Logger.Log(source, provider));

            return _loggers[source];
        }
    }
}
