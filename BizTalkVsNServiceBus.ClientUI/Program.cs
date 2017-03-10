using System;
using System.Threading.Tasks;
using BizTalkVsNServiceBus.Sample;
using BizTalkVsNServiceBus.Sample.Nsb.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.ClientUI
{
    public class Program
    {
        private static readonly ILog _logger;

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

        static async Task AsyncMain()
        {
            Console.Title = "ClientUI";

            var endpointConfiguration = new EndpointConfiguration("BizTalkVsNServiceBus.ClientUI");

            var transport = endpointConfiguration.UseTransport<MsmqTransport>();

            var routingSettings = transport.Routing();
            routingSettings.RouteToEndpoint(typeof(OrderMessage), "BizTalkVsNServiceBus.Sample.BizTalk.InputQueue");

            endpointConfiguration.UseSerialization<XmlSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            await RunLoop(endpointInstance);

            await endpointInstance.Stop().ConfigureAwait(false);
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                _logger.Info("Press 'P' to place an order, or 'Q' to quit.");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:

                        // Instantiate an order
                        var order = new OrderMessage()
                        {
                            OrderId = "123456",
                            OrderStatus = 2,
                            OrderDate = new DateTime(2017,03,09),
                            Customer = new OrderMessageCustomer
                            {
                                FirstName = "Abderrahman",
                                LastName = "Cheddir"
                            }
                        };

                        _logger.Info($"Sending order, OrderId = {order.OrderId}");
                        await endpointInstance.Send(order).ConfigureAwait(false);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        _logger.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
