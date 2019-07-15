using System;
using System.IO;

namespace das.Extensions.Logger.LogWriters
{
    public class DailyFileLogWriter : LogWriter
    {
        private readonly object _sync = new object();

        public override void WriteEvent(LogEvent logEvent)
        {
            if (!IsEnabled(logEvent)) return;

            string LogFile()
            {
                return Path.Combine(AppEnv.GetPath(), string.IsNullOrEmpty(Name) ? $"{AppEnv.Name}[{DateTime.Now:yyyy-MM-dd}].log" : $"{AppEnv.Name}({Name})[{DateTime.Now:yyyy-MM-dd}].log");
            }

            lock (_sync)
            {
                File.AppendAllText(LogFile(), logEvent.ToString(Format) + Environment.NewLine);
            }
        }
    }
}