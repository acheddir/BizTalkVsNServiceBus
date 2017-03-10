using System.Threading.Tasks;
using BizTalkVsNServiceBus.Sample.Nsb.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.Sample.OutputServer
{
    public class OutOrderMessageHandler : IHandleMessages<OrderMessage>
    {
        private static ILog _logger = LogManager.GetLogger<OutOrderMessageHandler>();

        public Task Handle(OrderMessage message, IMessageHandlerContext context)
        {
            _logger.Info($"Order Successfully Received From BizTalk - Order: {message.OrderId}");

            return Task.CompletedTask;
        }
    }
}