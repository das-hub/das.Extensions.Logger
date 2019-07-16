using System;
using System.Reflection;

namespace das.Extensions.Logger
{
    public class LoggerEnvironment
    {
        public LoggerEnvironment()
        {
            AppName = Assembly.GetEntryAssembly().GetName().Name;
            Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{AppName}.LOG");
        }

        public string AppName { get; }
        public string Path { get; }
    }
}
