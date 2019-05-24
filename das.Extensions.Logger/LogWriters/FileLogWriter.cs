using System;
using System.IO;

namespace das.Extensions.Logger.LogWriters
{
    public class FileLogWriter : LogWriter
    {
        private string LogFile()
        {
            return Path.Combine(AppEnv.GetPath(), string.IsNullOrEmpty(Name) ? $"{AppEnv.Name}.log" : $"{AppEnv.Name}({Name}).log");
        }

        protected override void WriteLine(LogEvent logEvent)
        {
            File.AppendAllText(LogFile(),
                logEvent.ToString(Format) +
                Environment.NewLine);
        }
    }
}