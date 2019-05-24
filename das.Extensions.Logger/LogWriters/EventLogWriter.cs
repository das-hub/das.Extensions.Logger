using System.Diagnostics;

namespace das.Extensions.Logger.LogWriters
{
    public class EventLogWriter : LogWriter
    {
        private EventLog _eventLog;
        
        private void EventLogInit()
        {
            if (_eventLog != null) return;

            string source = string.IsNullOrEmpty(Name) ? $"{AppEnv.Name}" : $"{AppEnv.Name}({Name})";

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }

            _eventLog = new EventLog
            {
                Source = source
            };
        }

        protected override void WriteLine(LogEvent logEvent)
        {
            EventLogInit();

            EventLogEntryType type = EventLogEntryType.Information;

            switch (logEvent.Level)
            {
                case LogLevel.Error: type = EventLogEntryType.Error; break;
                case LogLevel.Warning: type = EventLogEntryType.Warning; break;
            }
          
            _eventLog.WriteEntry(logEvent.Message, type);
        }
    }
}