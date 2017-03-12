namespace BizTalkVsNServiceBus.Sample.BizTalk {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BizTalkVsNServiceBus.Sample.BizTalk.OrderMessage", typeof(global::BizTalkVsNServiceBus.Sample.BizTalk.OrderMessage))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BizTalkVsNServiceBus.Sample.BizTalk.CustomerMessage", typeof(global::BizTalkVsNServiceBus.Sample.BizTalk.CustomerMessage))]
    public sealed class Order2Customer : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0"" xmlns:ns0=""http://tempuri.net/BizTalkVsNServiceBus.Sample.Nsb.Messages"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/ns0:OrderMessage"" />
  </xsl:template>
  <xsl:template match=""/ns0:OrderMessage"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(string(Customer/FirstName/text()) , &quot; &quot; , string(Customer/LastName/text()))"" />
    <ns0:CustomerMessage>
      <FullName>
        <xsl:value-of select=""$var:v1"" />
      </FullName>
      <OrderId>
        <xsl:value-of select=""OrderId/text()"" />
      </OrderId>
    </ns0:CustomerMessage>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string StringConcat(string param0, string param1, string param2)
{
   return param0 + param1 + param2;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BizTalkVsNServiceBus.Sample.BizTalk.OrderMessage";
        
        private const global::BizTalkVsNServiceBus.Sample.BizTalk.OrderMessage _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BizTalkVsNServiceBus.Sample.BizTalk.CustomerMessage";
        
        private const global::BizTalkVsNServiceBus.Sample.BizTalk.CustomerMessage _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"BizTalkVsNServiceBus.Sample.BizTalk.OrderMessage";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"BizTalkVsNServiceBus.Sample.BizTalk.CustomerMessage";
                return _TrgSchemas;
            }
        }
    }
}
