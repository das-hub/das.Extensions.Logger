using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using das.Extensions.Logger.Abstractions;

namespace das.Extensions.Logger.LogWriters
{
    public abstract class LogWriter : ILogWriter
    {
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

        public bool IsEnabled(LogEvent logEvent)
        {
            return Condition == null || Condition(logEvent);
        }

        public abstract void WriteEvent(LogEvent logEvent);
    }

    public class Writers : List<ILogWriter> { }
}
