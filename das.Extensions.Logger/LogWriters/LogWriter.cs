using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace das.Extensions.Logger.LogWriters
{
    public abstract class LogWriter
    {
        [XmlIgnore]
        public Func<LogEvent, bool> Condition;

        protected LogWriter()
        {
            Condition = logEvent => string.IsNullOrEmpty(Source)
                ? logEvent.Level >= MinLevel && logEvent.Level <= MaxLevel 
                : logEvent.Source.Contains(Source) && logEvent.Level >= MinLevel && logEvent.Level <= MaxLevel;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("format")]
        public string Format { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        [XmlAttribute("min-level")]
        public LogLevel MinLevel { get; set; } = LogLevel.Error;

        [XmlAttribute("max-level")]
        public LogLevel MaxLevel { get; set; } = LogLevel.Error;

        public bool IsEnabled(LogEvent logEvent)
        {
            return Condition == null || Condition(logEvent);
        }

        public abstract void WriteEvent(LogEvent logEvent);
    }

    public class Writers : List<LogWriter> { }
}
