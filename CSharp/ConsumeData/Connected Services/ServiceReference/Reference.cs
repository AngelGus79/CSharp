﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumeData.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento HelloWorldResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        ConsumeData.ServiceReference.HelloWorldResponse HelloWorld(ConsumeData.ServiceReference.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsumeData.ServiceReference.HelloWorldResponse> HelloWorldAsync(ConsumeData.ServiceReference.HelloWorldRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento IsOddResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsOdd", ReplyAction="*")]
        ConsumeData.ServiceReference.IsOddResponse IsOdd(ConsumeData.ServiceReference.IsOddRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsOdd", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsumeData.ServiceReference.IsOddResponse> IsOddAsync(ConsumeData.ServiceReference.IsOddRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public ConsumeData.ServiceReference.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(ConsumeData.ServiceReference.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public ConsumeData.ServiceReference.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(ConsumeData.ServiceReference.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsOddRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsOdd", Namespace="http://tempuri.org/", Order=0)]
        public ConsumeData.ServiceReference.IsOddRequestBody Body;
        
        public IsOddRequest() {
        }
        
        public IsOddRequest(ConsumeData.ServiceReference.IsOddRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsOddRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int number;
        
        public IsOddRequestBody() {
        }
        
        public IsOddRequestBody(int number) {
            this.number = number;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsOddResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsOddResponse", Namespace="http://tempuri.org/", Order=0)]
        public ConsumeData.ServiceReference.IsOddResponseBody Body;
        
        public IsOddResponse() {
        }
        
        public IsOddResponse(ConsumeData.ServiceReference.IsOddResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsOddResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string IsOddResult;
        
        public IsOddResponseBody() {
        }
        
        public IsOddResponseBody(string IsOddResult) {
            this.IsOddResult = IsOddResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : ConsumeData.ServiceReference.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<ConsumeData.ServiceReference.WebService1Soap>, ConsumeData.ServiceReference.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsumeData.ServiceReference.HelloWorldResponse ConsumeData.ServiceReference.WebService1Soap.HelloWorld(ConsumeData.ServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            ConsumeData.ServiceReference.HelloWorldRequest inValue = new ConsumeData.ServiceReference.HelloWorldRequest();
            inValue.Body = new ConsumeData.ServiceReference.HelloWorldRequestBody();
            ConsumeData.ServiceReference.HelloWorldResponse retVal = ((ConsumeData.ServiceReference.WebService1Soap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsumeData.ServiceReference.HelloWorldResponse> ConsumeData.ServiceReference.WebService1Soap.HelloWorldAsync(ConsumeData.ServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsumeData.ServiceReference.HelloWorldResponse> HelloWorldAsync() {
            ConsumeData.ServiceReference.HelloWorldRequest inValue = new ConsumeData.ServiceReference.HelloWorldRequest();
            inValue.Body = new ConsumeData.ServiceReference.HelloWorldRequestBody();
            return ((ConsumeData.ServiceReference.WebService1Soap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsumeData.ServiceReference.IsOddResponse ConsumeData.ServiceReference.WebService1Soap.IsOdd(ConsumeData.ServiceReference.IsOddRequest request) {
            return base.Channel.IsOdd(request);
        }
        
        public string IsOdd(int number) {
            ConsumeData.ServiceReference.IsOddRequest inValue = new ConsumeData.ServiceReference.IsOddRequest();
            inValue.Body = new ConsumeData.ServiceReference.IsOddRequestBody();
            inValue.Body.number = number;
            ConsumeData.ServiceReference.IsOddResponse retVal = ((ConsumeData.ServiceReference.WebService1Soap)(this)).IsOdd(inValue);
            return retVal.Body.IsOddResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsumeData.ServiceReference.IsOddResponse> ConsumeData.ServiceReference.WebService1Soap.IsOddAsync(ConsumeData.ServiceReference.IsOddRequest request) {
            return base.Channel.IsOddAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsumeData.ServiceReference.IsOddResponse> IsOddAsync(int number) {
            ConsumeData.ServiceReference.IsOddRequest inValue = new ConsumeData.ServiceReference.IsOddRequest();
            inValue.Body = new ConsumeData.ServiceReference.IsOddRequestBody();
            inValue.Body.number = number;
            return ((ConsumeData.ServiceReference.WebService1Soap)(this)).IsOddAsync(inValue);
        }
    }
}