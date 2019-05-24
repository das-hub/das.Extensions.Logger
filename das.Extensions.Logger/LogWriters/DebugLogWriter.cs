using System.Diagnostics;

namespace das.Extensions.Logger.LogWriters
{
    public class DebugLogWriter : LogWriter
    {
        protected override void WriteLine(LogEvent logEvent)
        {
            Debug.WriteLine(logEvent.ToString(Format));
        }
    }
}