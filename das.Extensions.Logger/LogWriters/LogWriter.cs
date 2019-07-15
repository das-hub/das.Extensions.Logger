using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace das.Extensions.Logger.LogWriters
{
    public abstract class LogWriter
    {
        private readonly object _lock = new object();

        public Func<LogEvent, bool> Condition;

        protected LogWriter()
        {
            Condition = logEvent => string.IsNullOrEmpty(Source)
                ? logEvent.Level >= MinLevel
                : logEvent.Source.Contains(Source) && logEvent.Level >= MinLevel;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("format")]
        public string Format { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("min-level")]
        public LogLevel MinLevel { get; set; } = LogLevel.Error;

        protected bool IsEnabled(LogEvent logEvent)
        {
            return Condition == null || Condition(logEvent);
        }

        public void WriteEvent(LogEvent logEvent)
        {
            if (!IsEnabled(logEvent)) return;

            lock (_lock)
            {
                WriteLine(logEvent);
            }
        }

        protected abstract void WriteLine(LogEvent logEvent);
    }

    public class Writers : List<LogWriter> { }
}
