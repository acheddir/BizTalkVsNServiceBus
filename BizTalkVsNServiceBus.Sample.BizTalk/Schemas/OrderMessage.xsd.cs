namespace BizTalkVsNServiceBus.Sample.BizTalk {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://tempuri.net/BizTalkVsNServiceBus.Sample.Nsb.Messages",@"OrderMessage")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"OrderMessage"})]
    public sealed class OrderMessage : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://tempuri.net/BizTalkVsNServiceBus.Sample.Nsb.Messages"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://tempuri.net/BizTalkVsNServiceBus.Sample.Nsb.Messages"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""OrderMessage"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""OrderId"" type=""xs:ID"" />
        <xs:element name=""OrderDate"" type=""xs:dateTime"" />
        <xs:element name=""OrderStatus"" type=""xs:byte"" />
        <xs:element name=""Customer"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""FirstName"" type=""xs:string"" />
              <xs:element name=""LastName"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public OrderMessage() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "OrderMessage";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
