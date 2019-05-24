using System;
using System.IO;

namespace das.Extensions.Logger.LogWriters
{
    public class EveryDayFileLogWriter : LogWriter
    {
        private string LogFile()
        {
            return Path.Combine(AppEnv.GetPath(), string.IsNullOrEmpty(Name) ? $"{AppEnv.Name}[{DateTime.Now:yyyy-MM-dd}].log" : $"{AppEnv.Name}({Name})[{DateTime.Now:yyyy-MM-dd}].log");
        }

        protected override void WriteLine(LogEvent logEvent)
        {            
            File.AppendAllText(LogFile(),
                logEvent.ToString(Format) +
                Environment.NewLine);
        }
    }
}