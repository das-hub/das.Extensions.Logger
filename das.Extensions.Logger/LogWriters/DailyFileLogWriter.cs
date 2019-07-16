using System;
using System.IO;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger.LogWriters
{
    public class DailyFileLogWriter : LogWriter
    {
        private readonly object _sync = new object();

        public override void WriteEvent(LogEvent logEvent, LoggerEnvironment environment)
        {
            lock (_sync)
            {
                File.AppendAllText(environment.GetLogFile(environment.GetDailyLogFileName(Name)), logEvent.ToString(Format) + Environment.NewLine);
            }
        }
    }
}