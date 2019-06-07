// <copyright file="Logger.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common
{
    using System.Reflection;
    using log4net;
    using log4net.Config;
    using log4net.Core;
    using log4net.Repository.Hierarchy;

    /// <summary>
    /// Logger
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Setups the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        public static void Setup(LogLevel level)
        {
            var loggerRepo = LogManager.GetRepository(Assembly.GetCallingAssembly());

            BasicConfigurator.Configure(loggerRepo);

            var hierarchy = (Hierarchy)loggerRepo;

            hierarchy.Root.Level = GetLogLevel(level);
            hierarchy.Configured = true;
        }

        private static Level GetLogLevel(LogLevel level)
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