using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Uml.Robotics.Ros
{
    public static class ApplicationLogging
    {
        private static ILoggerFactory loggerFactory;

        public static LogLevel ConsoleLogLevel { get; set; } = LogLevel.Information;

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                lock (typeof(ApplicationLogging))
                {
                    if (loggerFactory == null)
                    {
                        // Here a method had been used that was marked as obsolete in Microsoft.Extensions.Logging 2.2
                        // and has been removed in version 3.0 -> this is the workaround for it.
                        // Refactoring the whole thing to make use of dependencyInjection will become necessary at some
                        // point in the future.
                        var configureNamedOptions = new ConfigureNamedOptions<ConsoleLoggerOptions>("", null);
                        var postConfigureOptions = Enumerable.Empty<IPostConfigureOptions<ConsoleLoggerOptions>>();
                        var setups = new []{ configureNamedOptions };
                        var optionsFactory = new OptionsFactory<ConsoleLoggerOptions>(setups, postConfigureOptions);
                        var optionsChangeTokenSources = Enumerable.Empty<IOptionsChangeTokenSource<ConsoleLoggerOptions>>();
                        var optionsMonitorCache = new OptionsCache<ConsoleLoggerOptions>();
                        var optionsMonitor = new OptionsMonitor<ConsoleLoggerOptions>(optionsFactory, optionsChangeTokenSources, optionsMonitorCache);
                        var loggerFilterOptions = new LoggerFilterOptions { MinLevel = ConsoleLogLevel };
                        var consoleLoggerProvider = new ConsoleLoggerProvider(optionsMonitor);
                        
                        loggerFactory = new LoggerFactory(new[] { consoleLoggerProvider }, loggerFilterOptions);
                        
                    }
                    return loggerFactory;
                }
            }
            set
            {
                lock (typeof(ApplicationLogging))
                {
                    loggerFactory = value;
                }
            }
        }

        public static ILogger CreateLogger<T>() =>
            LoggerFactory.CreateLogger<T>();

        public static ILogger CreateLogger(string category) =>
            LoggerFactory.CreateLogger(category);
    }
}
