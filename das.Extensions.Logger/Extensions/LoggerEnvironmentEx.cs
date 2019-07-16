using System;
using System.IO;

namespace das.Extensions.Logger.Extensions
{
    public static class LoggerEnvironmentEx
    {
        public static string GetPath(this LoggerEnvironment environment)
        {
            return Directory.CreateDirectory(environment.Path).FullName;
        }

        public static string GetLogFileName(this LoggerEnvironment environment, string name)
        {
            return string.IsNullOrEmpty(name) ? $"{environment.AppName}.log" : $"{environment.AppName}({name}).log";
        }

        public static string GetDailyLogFileName(this LoggerEnvironment environment, string name)
        {
            return string.IsNullOrEmpty(name) ? $"{environment.AppName}[{DateTime.Now:yyyy-MM-dd}].log" : $"{environment.AppName}({name})[{DateTime.Now:yyyy-MM-dd}].log";
        }

        public static string GetLogFile(this LoggerEnvironment environment, string logFileName)
        {
            return Path.Combine(environment.GetPath(), logFileName);
        }
    }
}
