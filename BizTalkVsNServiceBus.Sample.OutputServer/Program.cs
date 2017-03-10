using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.Sample.OutputServer
{
    public class Program
    {
        private static ILog _logger;

        static Program()
        {
            LogHelper.InitLogging();

            _logger = LogManager.GetLogger<Program>();
        }

        protected Program() { }

        private static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            Console.Title = "OutputServer";

            try
            {
                _logger.Info("Intializing Endpoint...");

                var config = new EndpointConfiguration("BizTalkVsNServiceBus.Sample.BizTalk.OutputQueue");

                config.UseTransport<MsmqTransport>();

                config.UseSerialization<XmlSerializer>();

                config.UsePersistence<InMemoryPersistence>();
                config.SendFailedMessagesTo("BizTalkVsNServiceBus.Sample.BizTalk.Error");
                config.EnableInstallers();

                var endpointInstance = await Endpoint.Start(config).ConfigureAwait(false);

                _logger.Info("Endpoint Started.");

                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();

                await endpointInstance.Stop().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                //Log Error
                _logger.Error($"Exception from NServiceBusIsolatedHost: {e}");
            }
        }
    }
}
