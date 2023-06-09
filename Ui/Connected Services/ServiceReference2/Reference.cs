﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="tokenResponse", Namespace="http://schemas.datacontract.org/2004/07/Token")]
    public partial class tokenResponse : object
    {
        
        private string messageField;
        
        private bool resultField;
        
        private string tokenField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ITokens")]
    public interface ITokens
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITokens/MakeToken", ReplyAction="http://tempuri.org/ITokens/MakeTokenResponse")]
        System.Threading.Tasks.Task<ServiceReference2.tokenResponse> MakeTokenAsync(string amount, string merchantId, string invoiceNo, string paymentId, string specialPaymentId, string revertURL, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITokens/MakeSpecialToken", ReplyAction="http://tempuri.org/ITokens/MakeSpecialTokenResponse")]
        System.Threading.Tasks.Task<ServiceReference2.tokenResponse> MakeSpecialTokenAsync(string amount, string merchantId, string invoiceNo, string paymentId, string specialPaymentId, string revertURL, string description, string extraParam1, string extraParam2, string extraParam3, string extraParam4);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ITokensChannel : ServiceReference2.ITokens, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class TokensClient : System.ServiceModel.ClientBase<ServiceReference2.ITokens>, ServiceReference2.ITokens
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TokensClient() : 
                base(TokensClient.GetDefaultBinding(), TokensClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITokens.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TokensClient(EndpointConfiguration endpointConfiguration) : 
                base(TokensClient.GetBindingForEndpoint(endpointConfiguration), TokensClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TokensClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TokensClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TokensClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TokensClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TokensClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.tokenResponse> MakeTokenAsync(string amount, string merchantId, string invoiceNo, string paymentId, string specialPaymentId, string revertURL, string description)
        {
            return base.Channel.MakeTokenAsync(amount, merchantId, invoiceNo, paymentId, specialPaymentId, revertURL, description);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.tokenResponse> MakeSpecialTokenAsync(string amount, string merchantId, string invoiceNo, string paymentId, string specialPaymentId, string revertURL, string description, string extraParam1, string extraParam2, string extraParam3, string extraParam4)
        {
            return base.Channel.MakeSpecialTokenAsync(amount, merchantId, invoiceNo, paymentId, specialPaymentId, revertURL, description, extraParam1, extraParam2, extraParam3, extraParam4);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITokens))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITokens))
            {
                return new System.ServiceModel.EndpointAddress("https://ikc.shaparak.ir/TToken/Tokens.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TokensClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITokens);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TokensClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITokens);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITokens,
        }
    }
}
