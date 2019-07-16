using System;
using System.IO;

namespace das.Extensions.Logger.LogWriters
{
    public class DailyFileLogWriter : LogWriter
    {
        private readonly object _sync = new object();

        public override void WriteEvent(LogEvent logEvent)
        {
            string LogFile()
            {
                return Path.Combine(AppEnv.GetPath(), AppEnv.GetDailyLogFileName(Name));
            }

            lock (_sync)
            {
                File.AppendAllText(LogFile(), logEvent.ToString(Format) + Environment.NewLine);
            }
        }
    }
}