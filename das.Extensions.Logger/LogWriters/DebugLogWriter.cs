using System.Diagnostics;

namespace das.Extensions.Logger.LogWriters
{
    public class DebugLogWriter : LogWriter
    {
        public override void WriteEvent(LogEvent logEvent, LoggerEnvironment environment)
        {
            Debug.WriteLine(logEvent.ToString(Format));
        }
    }
}