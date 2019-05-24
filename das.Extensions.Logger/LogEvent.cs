using System;
using das.Extensions.Logger.Extensions;

namespace das.Extensions.Logger
{
    public class LogEvent
    {
        public LogLevel Level { get; set; }
        public DateTime DateTime => DateTime.Now;
        public string Source { get; set; }
        public string Message { get; set; }

        public static LogEvent Create(LogLevel level, string source, string message)
        {
            return new LogEvent { Level = level, Source = source, Message = message };
        }

        public override string ToString()
        {
            return $"{DateTime:dd.MM.yyyy HH:mm:ss}|{this.LevelToString().Substring(0,1)}|{Source}|{Message}";
        }

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
                return ToString();

            string result = this.Bind(format).Set("DateTime", e => e.DateTime)
                .Set("Source", e => e.Source)
                .Set("Level", e => e.LevelToString())
                .Set("Message", e => e.Message).Result();

            return result;
        }
    }
}