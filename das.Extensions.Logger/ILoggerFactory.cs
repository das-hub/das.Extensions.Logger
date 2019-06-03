using System;
using System.Collections.Generic;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string source = null, LoggerProvider provider = null);
        ILogger ReconfigureLogger(string source, LoggerProvider provider);
    }

    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, ILogger> _loggers = new Dictionary<string, ILogger>(StringComparer.Ordinal);
        private readonly LoggerProvider _defaultProvider;

        public LoggerFactory(LoggerProvider provider)
        {
            _defaultProvider = provider;
        }

        public static ILoggerFactory CreateFactory(LoggerProvider provider)
        {
            return new LoggerFactory(provider);
        }

        public ILogger CreateLogger(string source = null, LoggerProvider provider = null)
        {
            return AddLogger(source.ValueOrDefault(AppEnv.Name), provider ?? _defaultProvider);
        }

        public ILogger ReconfigureLogger(string source, LoggerProvider provider)
        {
            if (_loggers.ContainsKey(source)) _loggers.Remove(source);
            return AddLogger(source, provider);
        }

        private ILogger AddLogger(string source, LoggerProvider provider)
        {
            if (!_loggers.ContainsKey(source))
                _loggers.Add(source, Logger.Log(source, provider));

            return _loggers[source];
        }
    }
}
