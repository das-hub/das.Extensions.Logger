using System;
using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger.Extensions
{
    public static class LoggerProviderEx
    {
        public static LoggerProvider AddConsole(this LoggerProvider provider, string name="", string source = "", string format = "", LogLevel minLevel = LogLevel.Info, LogLevel maxLevel = LogLevel.Info, Func<LogEvent, bool> condition = null)
        {
            ConsoleLogWriter writer = new ConsoleLogWriter{
                Name = name,
                Format = format,
                Source = source,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
            };

            if (condition != null) writer.Condition = condition;

            provider.Writers.Add(writer);

            return provider; 
        }

        public static LoggerProvider AddFile(this LoggerProvider provider, string name = "", string source = "", string format = "", LogLevel minLevel = LogLevel.Info, LogLevel maxLevel = LogLevel.Info, Func<LogEvent, bool> condition = null)
        {
            FileLogWriter writer = new FileLogWriter
            {
                Name = name,
                Format = format,
                Source = source,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
            };

            if (condition != null) writer.Condition = condition;

            provider.Writers.Add(writer);

            return provider;
        }

        public static LoggerProvider AddDailyFile(this LoggerProvider provider, string name = "", string source = "", string format = "", LogLevel minLevel = LogLevel.Info, LogLevel maxLevel = LogLevel.Info, Func<LogEvent, bool> condition = null)
        {
            DailyFileLogWriter writer = new DailyFileLogWriter
            {
                Name = name,
                Format = format,
                Source = source,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
            };

            if (condition != null) writer.Condition = condition;

            provider.Writers.Add(writer);

            return provider;
        }

        public static LoggerProvider AddDebug(this LoggerProvider provider, string name = "", string source = "", string format = "", LogLevel minLevel = LogLevel.Info, LogLevel maxLevel = LogLevel.Info, Func<LogEvent, bool> condition = null)
        {
            DebugLogWriter writer = new DebugLogWriter
            {
                Name = name,
                Format = format,
                Source = source,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
            };

            if (condition != null) writer.Condition = condition;

            provider.Writers.Add(writer);

            return provider;
        }
    }
}