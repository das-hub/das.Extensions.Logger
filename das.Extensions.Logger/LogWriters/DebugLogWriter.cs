using System.Diagnostics;

namespace das.Extensions.Logger.LogWriters
{
    public class DebugLogWriter : LogWriter
    {
        public override void WriteEvent(LogEvent logEvent)
        {
            Debug.WriteLine(logEvent.ToString(Format));
        }
    }
}