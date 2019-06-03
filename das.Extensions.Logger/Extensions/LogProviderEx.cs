using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger.Extensions
{
    public static class LogProviderEx
    {
        public static LogProvider AddConsole(this LogProvider provider, string name="", string format = "", bool info=true, bool error = true, bool warn = true, bool debug = true)
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

        public static LogProvider AddFile(this LogProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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

        public static LogProvider AddEveryDayFile(this LogProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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

        public static LogProvider AddDebug(this LogProvider provider, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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