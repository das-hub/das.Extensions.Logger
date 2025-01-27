﻿using System;
using System.Collections.Generic;
using das.Extensions.Logger.Abstractions;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, ILogger> _loggers = new Dictionary<string, ILogger>(StringComparer.Ordinal);
        private readonly LoggerEnvironment _environment = new LoggerEnvironment();
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
            return AddLogger(source.ValueOrDefault(_environment.AppName), provider ?? _defaultProvider);
        }

        public ILogger ReconfigureLogger(string source, LoggerProvider provider)
        {
            if (_loggers.ContainsKey(source)) _loggers.Remove(source);
            return AddLogger(source, provider);
        }

        private ILogger AddLogger(string source, LoggerProvider provider)
        {
            if (!_loggers.ContainsKey(source))
                _loggers.Add(source, Logger.Log(source, provider, _environment));

            return _loggers[source];
        }
    }
}
