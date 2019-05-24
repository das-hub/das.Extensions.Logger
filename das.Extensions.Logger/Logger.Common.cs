using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using das.Extensions.Logger.LogWriters;

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
    }

    public class Writers : List<LogWriter> { }
}
