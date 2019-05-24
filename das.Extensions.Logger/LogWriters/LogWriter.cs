using System.Xml.Serialization;

namespace das.Extensions.Logger.LogWriters
{
    public abstract class LogWriter
    {
        private readonly object _lock = new object();

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("debug")]
        public bool IsDebug { get; set; }

        [XmlAttribute("info")]
        public bool IsInfo { get; set; }

        [XmlAttribute("error")]
        public bool IsError { get; set; }

        [XmlAttribute("warn")]
        public bool IsWarn { get; set; }

        [XmlAttribute("format")]
        public string Format { get; set; }

        public void WriteEvent(LogEvent logEvent)
        {
            lock (_lock)
            {
                if (IsDebug && logEvent.Level == LogLevel.Debug) WriteLine(logEvent);
                if (IsInfo && logEvent.Level == LogLevel.Info) WriteLine(logEvent);
                if (IsWarn && logEvent.Level == LogLevel.Warning) WriteLine(logEvent);
                if (IsError && logEvent.Level == LogLevel.Error) WriteLine(logEvent);
            }
        }

        protected abstract void WriteLine(LogEvent logEvent);
    }
}
