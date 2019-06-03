using System.Xml.Serialization;
using das.Extensions.Logging.LogWriters;

namespace das.Extensions.Logging.LogConfiguration
{
    public class LogWriters
    {
        public static LogWriters Empty => new LogWriters();

        public LogWriters()
        {
            Writers = new Writers();
        }

        [XmlElement("console", typeof(ConsoleLogWriter))]
        [XmlElement("everyday-file", typeof(EveryDayFileLogWriter))]
        [XmlElement("file", typeof(FileLogWriter))]
        [XmlElement("system", typeof(EventLogWriter))]
        [XmlElement("debug", typeof(DebugLogWriter))]
        public Writers Writers { get; set; }
    }
}