using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;


namespace YAMLParser
{
    public static class ApplicationLogging
    {
        private static ILoggerFactory _loggerFactory;

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if(_loggerFactory == null)
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
                    var loggerFilterOptions = new LoggerFilterOptions { MinLevel = LogLevel.Debug };
                    var consoleLoggerProvider = new ConsoleLoggerProvider(optionsMonitor);
                        
                    _loggerFactory = new LoggerFactory(new[] { consoleLoggerProvider }, loggerFilterOptions);
                }
                return _loggerFactory;
            }
            set
            {
                _loggerFactory = value;
            }
        }

        public static ILogger CreateLogger<T>() =>
            LoggerFactory.CreateLogger<T>();

        public static ILogger CreateLogger(string category) =>
            LoggerFactory.CreateLogger(category);
    }

}