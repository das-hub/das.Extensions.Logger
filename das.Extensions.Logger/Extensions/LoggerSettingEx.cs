using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger.Extensions
{
    public static class LoggerSettingEx
    {
        public static LoggerSetting AddConsole(this LoggerSetting setting, string name="", string format = "", bool info=true, bool error = true, bool warn = true, bool debug = true)
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

            setting.Writers.Add(writer);

            return setting; 
        }

        public static LoggerSetting AddFile(this LoggerSetting setting, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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

            setting.Writers.Add(writer);

            return setting;
        }

        public static LoggerSetting AddEveryDayFile(this LoggerSetting setting, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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

            setting.Writers.Add(writer);

            return setting;
        }

        public static LoggerSetting AddDebug(this LoggerSetting setting, string name = "", string format = "", bool info = true, bool error = true, bool warn = true, bool debug = true)
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

            setting.Writers.Add(writer);

            return setting;
        }
    }
}