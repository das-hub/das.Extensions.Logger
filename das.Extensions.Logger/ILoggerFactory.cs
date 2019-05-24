using System;
using System.Collections.Generic;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string source = null, LoggerSetting setting = null);
        ILogger ReconfigureLogger(string source, LoggerSetting setting);
    }

    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>(StringComparer.Ordinal);
        private readonly LoggerSetting _defaultSetting;

        public LoggerFactory(LoggerSetting setting)
        {
            _defaultSetting = setting;
        }

        public static ILoggerFactory CreateFactory(LoggerSetting setting)
        {
            return new LoggerFactory(setting);
        }

        public ILogger CreateLogger(string source = null, LoggerSetting setting = null)
        {
            return AddLogger(source.ValueOrDefault(AppEnv.Name), setting ?? _defaultSetting);
        }

        public ILogger ReconfigureLogger(string source, LoggerSetting setting)
        {
            if (_loggers.ContainsKey(source)) _loggers.Remove(source);
            return AddLogger(source, setting);
        }

        private ILogger AddLogger(string source, LoggerSetting setting)
        {
            if (!_loggers.ContainsKey(source))
                _loggers.Add(source, Logger.Log(source, setting));

            return _loggers[source];
        }
    }
}
