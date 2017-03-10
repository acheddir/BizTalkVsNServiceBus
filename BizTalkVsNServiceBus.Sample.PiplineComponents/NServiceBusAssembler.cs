using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;

namespace BizTalkVsNServiceBus.Sample.PiplineComponents
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_AssemblingSerializer)]
    [Guid("c662c556-3fe3-4900-8abb-3124c1c4a3c6")]
    public class NServiceBusAssembler : IBaseComponent, IComponentUI, IPersistPropertyBag, IAssemblerComponent
    {
        private readonly Queue<IBaseMessage> _outputMessages = new Queue<IBaseMessage>();
        public string MessageNamespace { get; set; } = string.Empty;

        public string Version
            => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string Name
            => "NServiceBus Assembler";
        public string Description
            => "Assembler to correctly wrap and assemble messages to be sent to NServiceBus";

        public IEnumerator Validate(object projectSystem)
        {
            return null;
        }

        public IntPtr Icon => IntPtr.Zero;

        public void GetClassID(out Guid classID)
        {
            classID = new Guid("a055d772-b7fa-47f1-bc1d-601d6a1c2d1f");
        }

        public void InitNew()
        {
            //InitNew is empty for now
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            var namespaceProperty = ReadProperty(propertyBag, "MessageNamespace") as string;
            if (!string.IsNullOrEmpty(namespaceProperty))
                MessageNamespace = namespaceProperty;
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            if (this.MessageNamespace != null)
            {
                object messageNamespace = this.MessageNamespace;
                propertyBag.Write("MessageNamespace", ref messageNamespace);
            }
        }

        public void AddDocument(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            StreamReader messageReader = new StreamReader(pInMsg.BodyPart.GetOriginalDataStream());

            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append("<?xml version=\"1.0\"?>");
            messageBuilder.Append(messageReader.ReadToEnd().ExceptBlanks());

            MemoryStream newMessageStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(newMessageStream);
            writer.Write(messageBuilder.ToString());
            writer.Flush();
            newMessageStream.Seek(0, SeekOrigin.Begin);

            IBaseMessage outputMessage = pInMsg;
            outputMessage.BodyPart.Data = newMessageStream;
            _outputMessages.Enqueue(outputMessage);
        }

        public IBaseMessage Assemble(IPipelineContext pContext)
        {
            return _outputMessages != null && _outputMessages.Count > 0
                ? _outputMessages.Dequeue()
                : null;
        }

        public static object ReadProperty(IPropertyBag pb, string name)
        {
            try
            {
                object val;
                pb.Read(name, out val, 0);
                return val ?? string.Empty;
            }
            catch
            {
                return null;
            }
        }
    }
}