using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BizTalkVsNServiceBus.Sample.Nsb.Messages;
using Microsoft.Samples.BizTalk.Adapters.TransportProxyUtils;
using NServiceBus.Logging;

namespace BizTalkVsNServiceBus.Sample.NsbHost
{
    public class OrderMessageHandler : NServiceBus.IHandleMessages<OrderMessage>
    {
        private const string SubmitDirectAdapterUri = @"submit://NServiceBus/OneWay";
        private static ILog _logger = LogManager.GetLogger<OrderMessageHandler>();

        public Task Handle(OrderMessage message, NServiceBus.IMessageHandlerContext context)
        {
            try
            {
                var serializer = new XmlSerializer(message.GetType());
                var messageStream = new MemoryStream();
                serializer.Serialize(messageStream, message);
                messageStream.Seek(0, SeekOrigin.Begin);

                var btm = new BizTalkMessaging();
                var bizTalkMessage = btm.CreateMessageFromStream(SubmitDirectAdapterUri, null, messageStream);
                btm.SubmitMessage(bizTalkMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw; //Throwing the exception will allow NServiceBus to requeue and retry the message
            }

            return Task.CompletedTask;
        }
    }
}