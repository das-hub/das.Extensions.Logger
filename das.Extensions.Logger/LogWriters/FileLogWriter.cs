using System;
using System.IO;

namespace das.Extensions.Logger.LogWriters
{
    public class FileLogWriter : LogWriter
    {
        protected override void WriteLine(LogEvent logEvent)
        {
            string LogFile()
            {
                return Path.Combine(AppEnv.GetPath(), string.IsNullOrEmpty(Name) ? $"{AppEnv.Name}.log" : $"{AppEnv.Name}({Name}).log");
            }
            
            File.AppendAllText(LogFile(),
                logEvent.ToString(Format) +
                Environment.NewLine);
        }
    }
}