namespace BizTalkVsNServiceBus.Sample.BizTalk
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class NsbSendPipeline : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemb"+
"le\" minOccurs=\"0\" maxOccurs=\"1\" execMethod=\"All\" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />  "+
"    <Components>        <Component>          <Name>BizTalkVsNServiceBus.Sample.PiplineComponents.NSe"+
"rviceBusAssembler,BizTalkVsNServiceBus.Sample.PiplineComponents, Version=1.0.0.0, Culture=neutral, P"+
"ublicKeyToken=d0354708766a84e6</Name>          <ComponentName>NServiceBus Assembler</ComponentName> "+
"         <Description>Assembler to correctly wrap and assemble messages to be sent to NServiceBus</D"+
"escription>          <Version>1.0.0.0</Version>          <Properties>            <Property Name=\"Mes"+
"sageNamespace\">              <Value xsi:type=\"xsd:string\" />            </Property>          </Prope"+
"rties>          <CachedDisplayName>NServiceBus Assembler</CachedDisplayName>          <CachedIsManag"+
"ed>true</CachedIsManaged>        </Component>      </Components>    </Stage>    <Stage>      <Policy"+
"FileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Encode\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\""+
" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>  </Stages></Docum"+
"ent>";
        
        private const string _versionDependentGuid = "06399b01-8b29-4956-8605-f05df361878f";
        
        public NsbSendPipeline()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4107-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("BizTalkVsNServiceBus.Sample.PiplineComponents.NServiceBusAssembler,BizTalkVsNServiceBus.Sample.PiplineComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d0354708766a84e6");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"MessageNamespac"+
"e\">      <Value xsi:type=\"xsd:string\" />    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
