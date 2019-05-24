namespace das.Extensions.Logger.Extensions
{
    public static class LogEventEx
    {
        public static DataBinder Bind(this LogEvent e, string format)
        {
            return new DataBinder(e, format);
        }

        public static string LevelToString(this LogEvent e)
        {
            switch (e.Level)
            {
                case LogLevel.Debug:
                    return "DBUG";
                case LogLevel.Info:
                    return "INFO";
                case LogLevel.Warning:
                    return "WARN";
                case LogLevel.Error:
                    return "FAIL";
                default:
                    return "NONE";
            }
        }
    }
}
