using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Mbed.Cloud.Foundation.Common
{
    public class Logger
    {
        public static void Setup()
        {
            var loggerRepo = LogManager.GetRepository(Assembly.GetCallingAssembly());

            BasicConfigurator.Configure(loggerRepo);

            Hierarchy hierarchy = (Hierarchy)loggerRepo;

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }
    }
}