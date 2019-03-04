using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Mbed.Cloud.Common
{
    public class Logger
    {
        public static void Setup(LogLevel level)
        {
            var loggerRepo = LogManager.GetRepository(Assembly.GetCallingAssembly());

            BasicConfigurator.Configure(loggerRepo);

            Hierarchy hierarchy = (Hierarchy)loggerRepo;

            hierarchy.Root.Level = getLogLevel(level);
            hierarchy.Configured = true;
        }

        private static Level getLogLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.ALL:
                    return Level.All;
                case LogLevel.DEBUG:
                    return Level.Debug;
                case LogLevel.ERROR:
                    return Level.Error;
                case LogLevel.FATAL:
                    return Level.Fatal;
                case LogLevel.INFO:
                    return Level.Info;
                case LogLevel.OFF:
                    return Level.Off;
                case LogLevel.WARN:
                    return Level.Warn;
                default:
                    return Level.All;
            }
        }
    }
}