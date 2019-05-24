using System.Xml.Serialization;
using das.Extensions.Logger.LogWriters;

namespace das.Extensions.Logger
{
    public class LoggerSetting
    {
        public static LoggerSetting Empty => new LoggerSetting();

        public LoggerSetting()
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