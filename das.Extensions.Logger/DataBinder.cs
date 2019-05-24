using System;
using System.Text.RegularExpressions;

namespace das.Extensions.Logger
{
    internal class DataBinder
    {
        private readonly LogEvent _event;
        private readonly string _format;

        internal DataBinder(LogEvent e, string format)
        {
            _event = e;
            _format = format;
        }

        internal DataBinder Set(string marker, Func<LogEvent, object> prop)
        {
            string pattern = @"{" + marker + @"(?<format>(.*?))}";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match match = regex.Match(_format);

            if (!match.Success) return this;

            string format = "{0" + match.Groups["format"] + "}";

            string result = string.Format(format, prop.Invoke(_event));

            return new DataBinder(_event, regex.Replace(_format, result));
        }

        internal string Result()
        {
            return _format;
        }
    }
}