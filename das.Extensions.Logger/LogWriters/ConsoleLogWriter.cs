using System;

namespace das.Extensions.Logger.LogWriters
{
    public class ConsoleLogWriter : LogWriter
    {
        public override void WriteEvent(LogEvent logEvent)
        {
            switch (logEvent.Level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(logEvent.ToString(Format));
            Console.ResetColor();
        }
    }
}