using System.Threading.Tasks;
using BizTalkVsNServiceBus.Sample.Nsb.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.Sample.OutputServer
{
    public class CustomerMessageHandler : IHandleMessages<CustomerMessage>
    {
        private static ILog _logger = LogManager.GetLogger<CustomerMessageHandler>();

        public Task Handle(CustomerMessage message, IMessageHandlerContext context)
        {
            _logger.Info($"Customer: \"{message.FullName}\" Successfully Placed Order N°: {message.OrderId}");

            return Task.CompletedTask;
        }
    }
}
