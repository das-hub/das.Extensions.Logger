using System;
using System.IO;
using System.Reflection;

namespace das.Extensions.Logger
{
    public static class AppEnv
    {
        public static string Name = Assembly.GetEntryAssembly().GetName().Name;
        public static string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Name}.LOG");

        public static string GetPath()
        {
            return Directory.CreateDirectory(Path).FullName;
        }

        public static string GetLogFileName(string name)
        {
            return string.IsNullOrEmpty(name) ? $"{Name}.log" : $"{Name}({name}).log";
        }

        public static string GetDailyLogFileName(string name)
        {
            return string.IsNullOrEmpty(name) ? $"{Name}[{DateTime.Now:yyyy-MM-dd}].log" : $"{Name}({name})[{DateTime.Now:yyyy-MM-dd}].log";
        }
    }
}
