﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference3
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseOfApiSpecialVerifyResponseXceKj1Fg", Namespace="http://schemas.datacontract.org/2004/07/Ipg.Engine.Model")]
    public partial class ResponseOfApiSpecialVerifyResponseXceKj1Fg : object
    {
        
        private string descriptionField;
        
        private string respCodeField;
        
        private ServiceReference3.ApiSpecialVerifyResponse resultField;
        
        private bool statusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string respCode
        {
            get
            {
                return this.respCodeField;
            }
            set
            {
                this.respCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference3.ApiSpecialVerifyResponse result
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
        public bool status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApiSpecialVerifyResponse", Namespace="http://schemas.datacontract.org/2004/07/Ipg.Engine.Model")]
    public partial class ApiSpecialVerifyResponse : object
    {
        
        private string CodeField;
        
        private string DescriptionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseOfApiRevereseResponseXceKj1Fg", Namespace="http://schemas.datacontract.org/2004/07/Ipg.Engine.Model")]
    public partial class ResponseOfApiRevereseResponseXceKj1Fg : object
    {
        
        private string descriptionField;
        
        private string respCodeField;
        
        private ServiceReference3.ApiRevereseResponse resultField;
        
        private bool statusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string respCode
        {
            get
            {
                return this.respCodeField;
            }
            set
            {
                this.respCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference3.ApiRevereseResponse result
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
        public bool status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApiRevereseResponse", Namespace="http://schemas.datacontract.org/2004/07/Ipg.Engine.Model")]
    public partial class ApiRevereseResponse : object
    {
        
        private string CodeField;
        
        private string DescriptionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="transactionModel", Namespace="http://schemas.datacontract.org/2004/07/VerifyPayment")]
    public partial class transactionModel : object
    {
        
        private string AMOUNTField;
        
        private string CARDNOField;
        
        private string EXTRAPARAM1Field;
        
        private string EXTRAPARAM2Field;
        
        private string EXTRAPARAM3Field;
        
        private string EXTRAPARAM4Field;
        
        private string MERCHANTIDField;
        
        private string PAYMENTIDField;
        
        private string REFERENCENUMBERField;
        
        private string RESULTCODEField;
        
        private string ROWNUMBERField;
        
        private string SETTLEMENTDATEField;
        
        private string SPECIALPAYMENTIDField;
        
        private string TRANSDATEField;
        
        private string VERIFYDATEField;
        
        private string VERIFYRESPONSEField;
        
        private string invoceNoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AMOUNT
        {
            get
            {
                return this.AMOUNTField;
            }
            set
            {
                this.AMOUNTField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CARDNO
        {
            get
            {
                return this.CARDNOField;
            }
            set
            {
                this.CARDNOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EXTRAPARAM1
        {
            get
            {
                return this.EXTRAPARAM1Field;
            }
            set
            {
                this.EXTRAPARAM1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EXTRAPARAM2
        {
            get
            {
                return this.EXTRAPARAM2Field;
            }
            set
            {
                this.EXTRAPARAM2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EXTRAPARAM3
        {
            get
            {
                return this.EXTRAPARAM3Field;
            }
            set
            {
                this.EXTRAPARAM3Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EXTRAPARAM4
        {
            get
            {
                return this.EXTRAPARAM4Field;
            }
            set
            {
                this.EXTRAPARAM4Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MERCHANTID
        {
            get
            {
                return this.MERCHANTIDField;
            }
            set
            {
                this.MERCHANTIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PAYMENTID
        {
            get
            {
                return this.PAYMENTIDField;
            }
            set
            {
                this.PAYMENTIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string REFERENCENUMBER
        {
            get
            {
                return this.REFERENCENUMBERField;
            }
            set
            {
                this.REFERENCENUMBERField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RESULTCODE
        {
            get
            {
                return this.RESULTCODEField;
            }
            set
            {
                this.RESULTCODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ROWNUMBER
        {
            get
            {
                return this.ROWNUMBERField;
            }
            set
            {
                this.ROWNUMBERField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SETTLEMENTDATE
        {
            get
            {
                return this.SETTLEMENTDATEField;
            }
            set
            {
                this.SETTLEMENTDATEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SPECIALPAYMENTID
        {
            get
            {
                return this.SPECIALPAYMENTIDField;
            }
            set
            {
                this.SPECIALPAYMENTIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TRANSDATE
        {
            get
            {
                return this.TRANSDATEField;
            }
            set
            {
                this.TRANSDATEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VERIFYDATE
        {
            get
            {
                return this.VERIFYDATEField;
            }
            set
            {
                this.VERIFYDATEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VERIFYRESPONSE
        {
            get
            {
                return this.VERIFYRESPONSEField;
            }
            set
            {
                this.VERIFYRESPONSEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string invoceNo
        {
            get
            {
                return this.invoceNoField;
            }
            set
            {
                this.invoceNoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CardModel", Namespace="http://schemas.datacontract.org/2004/07/VerifyPayment")]
    public partial class CardModel : object
    {
        
        private string CardNoField;
        
        private string HCodeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardNo
        {
            get
            {
                return this.CardNoField;
            }
            set
            {
                this.CardNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HCode
        {
            get
            {
                return this.HCodeField;
            }
            set
            {
                this.HCodeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference3.IVerify")]
    public interface IVerify
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/KicccPaymentsVerification", ReplyAction="http://tempuri.org/IVerify/KicccPaymentsVerificationResponse")]
        System.Threading.Tasks.Task<long> KicccPaymentsVerificationAsync(string token, string merchantId, string referenceNumber, string sha1Key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/KicccSpecialVerification", ReplyAction="http://tempuri.org/IVerify/KicccSpecialVerificationResponse")]
        System.Threading.Tasks.Task<ServiceReference3.ResponseOfApiSpecialVerifyResponseXceKj1Fg> KicccSpecialVerificationAsync(string token, string merchantId, string referenceNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/KicccReverse", ReplyAction="http://tempuri.org/IVerify/KicccReverseResponse")]
        System.Threading.Tasks.Task<ServiceReference3.ResponseOfApiRevereseResponseXceKj1Fg> KicccReverseAsync(string token, string merchantId, string referenceNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/getTransaction", ReplyAction="http://tempuri.org/IVerify/getTransactionResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel> getTransactionAsync(string merchantId, string invoiceNo, string referenceNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/transactionInquery", ReplyAction="http://tempuri.org/IVerify/transactionInqueryResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel> transactionInqueryAsync(string token, string merchantId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/getLimitedTransacction", ReplyAction="http://tempuri.org/IVerify/getLimitedTransacctionResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel> getLimitedTransacctionAsync(string merchantId, string invoiceNo, string amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/getDailyTransaction", ReplyAction="http://tempuri.org/IVerify/getDailyTransactionResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getDailyTransactionAsync(string merchantId, string offset, string limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/getOfflineTransaction", ReplyAction="http://tempuri.org/IVerify/getOfflineTransactionResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getOfflineTransactionAsync(string merchantId, string fromDate, string toDate, string offset, string limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/getTransactionByIban", ReplyAction="http://tempuri.org/IVerify/getTransactionByIbanResponse")]
        System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getTransactionByIbanAsync(string merchantId, string IbanNo, string fromDate, string toDate, string offset, string limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerify/GetCardsPerKey", ReplyAction="http://tempuri.org/IVerify/GetCardsPerKeyResponse")]
        System.Threading.Tasks.Task<ServiceReference3.CardModel[]> GetCardsPerKeyAsync(string merchantId, string key);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IVerifyChannel : ServiceReference3.IVerify, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class VerifyClient : System.ServiceModel.ClientBase<ServiceReference3.IVerify>, ServiceReference3.IVerify
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public VerifyClient() : 
                base(VerifyClient.GetDefaultBinding(), VerifyClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IVerify.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VerifyClient(EndpointConfiguration endpointConfiguration) : 
                base(VerifyClient.GetBindingForEndpoint(endpointConfiguration), VerifyClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VerifyClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(VerifyClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VerifyClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(VerifyClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public VerifyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<long> KicccPaymentsVerificationAsync(string token, string merchantId, string referenceNumber, string sha1Key)
        {
            return base.Channel.KicccPaymentsVerificationAsync(token, merchantId, referenceNumber, sha1Key);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.ResponseOfApiSpecialVerifyResponseXceKj1Fg> KicccSpecialVerificationAsync(string token, string merchantId, string referenceNumber)
        {
            return base.Channel.KicccSpecialVerificationAsync(token, merchantId, referenceNumber);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.ResponseOfApiRevereseResponseXceKj1Fg> KicccReverseAsync(string token, string merchantId, string referenceNumber)
        {
            return base.Channel.KicccReverseAsync(token, merchantId, referenceNumber);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel> getTransactionAsync(string merchantId, string invoiceNo, string referenceNo)
        {
            return base.Channel.getTransactionAsync(merchantId, invoiceNo, referenceNo);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel> transactionInqueryAsync(string token, string merchantId)
        {
            return base.Channel.transactionInqueryAsync(token, merchantId);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel> getLimitedTransacctionAsync(string merchantId, string invoiceNo, string amount)
        {
            return base.Channel.getLimitedTransacctionAsync(merchantId, invoiceNo, amount);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getDailyTransactionAsync(string merchantId, string offset, string limit)
        {
            return base.Channel.getDailyTransactionAsync(merchantId, offset, limit);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getOfflineTransactionAsync(string merchantId, string fromDate, string toDate, string offset, string limit)
        {
            return base.Channel.getOfflineTransactionAsync(merchantId, fromDate, toDate, offset, limit);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.transactionModel[]> getTransactionByIbanAsync(string merchantId, string IbanNo, string fromDate, string toDate, string offset, string limit)
        {
            return base.Channel.getTransactionByIbanAsync(merchantId, IbanNo, fromDate, toDate, offset, limit);
        }
        
        public System.Threading.Tasks.Task<ServiceReference3.CardModel[]> GetCardsPerKeyAsync(string merchantId, string key)
        {
            return base.Channel.GetCardsPerKeyAsync(merchantId, key);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IVerify))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IVerify))
            {
                return new System.ServiceModel.EndpointAddress("https://ikc.shaparak.ir/TVerify/Verify.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return VerifyClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IVerify);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return VerifyClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IVerify);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IVerify,
        }
    }
}
