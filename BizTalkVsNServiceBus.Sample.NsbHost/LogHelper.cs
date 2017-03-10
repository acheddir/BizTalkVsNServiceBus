using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using NServiceBus;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.Sample
{
    public static class LogHelper
    {
        public static void InitLogging()
        {
            var layout = new PatternLayout { ConversionPattern = "%date [%thread] %-5level %logger - %message%newline" };
            layout.ActivateOptions();

            var filter = new LevelRangeFilter { LevelMin = Level.Warn, LevelMax = Level.Fatal };
            filter.ActivateOptions();

            var eventLogAppender = new EventLogAppender
            {
                ApplicationName = "NServiceBus Sample Server",
                Threshold = Level.All,
                Layout = layout
            };
            eventLogAppender.AddFilter(filter);
            eventLogAppender.ActivateOptions();

            var consoleAppender = new ConsoleAppender
            {
                Threshold = Level.Info,
                Layout = layout
            };

            BasicConfigurator.Configure(consoleAppender);

            LogManager.Use<Log4NetFactory>();
        }
    }
}