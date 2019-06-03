using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger.Extensions
{
    public static class LoggerProviderEx
    {
        public static LoggerProvider AddConsole(this LoggerProvider provider, string name="", string format = "", bool info=true, bool error = true, bool warn = true, bool debug = true)
        {
            ConsoleLogWriter writer = new ConsoleLogWriter
            {
                Name = name,
                Format = format,
                IsDebug = debug,
                IsError = error,
                IsInfo = info,
                IsWarn = warn
            };

            provider.Writers.Add(writer);

            return provider; 
        }

        public static LoggerProvider AddFile(this LoggerProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
        {
            FileLogWriter writer = new FileLogWriter
            {
                Name = name,
                Format = format,
                IsDebug = debug,
                IsError = error,
                IsInfo = info,
                IsWarn = warn
            };

            provider.Writers.Add(writer);

            return provider;
        }

        public static LoggerProvider AddEveryDayFile(this LoggerProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
        {
            EveryDayFileLogWriter writer = new EveryDayFileLogWriter
            {
                Name = name,
                Format = format,
                IsDebug = debug,
                IsError = error,
                IsInfo = info,
                IsWarn = warn
            };

            provider.Writers.Add(writer);

            return provider;
        }

        public static LoggerProvider AddDebug(this LoggerProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
        {
            DebugLogWriter writer = new DebugLogWriter
            {
                Name = name,
                Format = format,
                IsDebug = debug,
                IsError = error,
                IsInfo = info,
                IsWarn = warn
            };

            provider.Writers.Add(writer);

            return provider;
        }
    }
}