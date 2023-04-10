using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml;

namespace Ui.Tools
{



    public class IPGDataModel
    {

        //[XmlElement("TreminalId")]
        /// <summary>
        /// کد پایانه 
        /// </summary>
        public string TreminalId { get; set; }
        /// <summary>
        /// کد پذیرنده 
        /// </summary>
        public string AcceptorId { get; set; }
        /// <summary>
        /// عبارت عبور
        /// </summary>
        public string PassPhrase { get; set; }
        /// <summary>
        /// مقدار-ریال
        /// </summary>
        public long Amount { get; set; }
        //{

        //    get { return amount; }

        //    set { amount = long.Parse(amount) }

        //}
        //Hard Code ip in xml file
        /// <summary>
        /// آدرس ارسال پاسخ نتیجه عملیات
        /// </summary>
        public string RevertURL { get; set; }
        /// <summary>
        /// شناسه پرداخت
        /// </summary>
        public string PaymentId { get; set; }
        /// <summary>
        /// شناسه درخواست
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// شناسه مرتبط با مشتری در سامانه های پذیرنده/پرداخت
        /// </summary>
        public string CmsPreservationId { get; set; }
        /// <summary>
        /// مشخص کننده نوع تراکنش
        /// </summary>
        public string TransactionType { get; set; }
        /// <summary>
        /// اطلاعات پرداخت
        /// </summary>
        public BillInfo BillInfo { get; set; }
        /// <summary>
        /// کلید عمومی
        /// </summary>
        public string RsaPublicKey { get; set; }

        /// <summary>
        /// شناسه مرتبط با مشتری در سامانه های پذیرنده/پرداخت
        /// </summary>
        public List<MultiplexParameter> MultiplexParameters { get; set; }

    }

    public class BillInfo
    {
        public string BillId { get; set; }
        public string billPaymentId { get; set; }

    }


    public class AssignXml
    {

        public IPGDataModel GetLoad()
        {

            SettingXML set = new SettingXML();
            IPGDataModel ad = new IPGDataModel();
            XmlDocument doc = new XmlDocument();




            ad.TreminalId = set.TreminalId; //doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("TreminalId")[0].InnerText;
            ad.AcceptorId = set.AcceptorId; //doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("AcceptorId")[0].InnerText;
            ad.PassPhrase = set.PassPhrase; //doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("PassPhrase")[0].InnerText;
            ad.Amount = 1000;


            return ad;



        }


    }


    public class IranKishPayment
    {
        /// <summary>
        /// دریافت توکن برای ورود به درگاه
        /// </summary>
        /// <param name="iPGData">اطلاعات درگاه</param>
        /// <param name="httpContext">اتصال</param>
        /// <returns></returns>
        public async Task getToken(IPGDataModel iPGData, HttpContext httpContext)
        {
            // خوندن اطلاعات
            XmlDocument doc = new XmlDocument();
            // پست کردن اطلاعات
            WebHelper webHelper = new WebHelper();



            try
            {


                doc.Load("DataXMLFile.xml");

                //string paymetId = new Random().Next().ToString();
                string paymetId = "10203040";
                //string requestId = new Random().Next().ToString();
                string requestId = "123456";
                string request = string.Empty;
                IPGDataModel _iPGData = new IPGDataModel();
                _iPGData.TreminalId = iPGData.TreminalId;
                _iPGData.AcceptorId = iPGData.AcceptorId;
                //آدرس برگشت اینجا ست می شود
                _iPGData.RevertURL = doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("URL")[0].InnerText;

                //it must be Converted to LONG!!
                _iPGData.Amount = iPGData.Amount;
                _iPGData.PaymentId = paymetId;
                _iPGData.RequestId = requestId;

                //the url that must be hard coded
                _iPGData.CmsPreservationId = iPGData.CmsPreservationId;//doc.SelectNodes("DocumentElement/IPGData")[0].SelectNodes("CmsPreservationId")[0].InnerText;
                _iPGData.TransactionType = TransactionType.Purchase;
                _iPGData.BillInfo = null;
                _iPGData.PassPhrase = iPGData.PassPhrase;

                // کلید عمومی 
                _iPGData.RsaPublicKey = doc.SelectNodes("DocumentElement/IPGData/RSAPublicKey")[0].InnerXml.ToString(); ;


                /// call json request 
                request = CreateJsonRequest.CreateJasonRequest(_iPGData);



                string url = doc.SelectNodes("DocumentElement/BaseAddress/token")[0].InnerXml.ToString();

                // پاس دادن اطلاعات ورودی به api
                string jresponse = await webHelper.Post(url, request);



                ////***
                ResultGatway resultJson = new ResultGatway();
                resultJson.SetResult(jresponse);
                ////**

                if (jresponse != null)
                {

                    TokenResult jResult = JsonConvert.DeserializeObject<TokenResult>(jresponse);

                    if (jResult.status)

                    {



                        string Token = jResult.result?.token;
                        var response = new HttpResponseMessage();
                        httpContext.Response?.Clear();
                        XmlNodeList xnList = doc.SelectNodes("DocumentElement/BaseAddress/payment");
                        var urlpayment = xnList[0].InnerXml.ToString();
                        var sb = new System.Text.StringBuilder();
                        sb.Append("<html>");
                        sb.AppendFormat("<body onload='document.forms[0].submit()'>");
                        sb.AppendFormat("<form action='{0}' method='post'>", urlpayment);

                        sb.AppendFormat("<input type='hidden' name='tokenIdentity' value='{0}'>", Token);
                        sb.Append("</form>");
                        sb.Append("</body>");
                        sb.Append("</html>");
                        await httpContext.Response?.WriteAsync(sb.ToString());



                    }



                }

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


    }



    public class WebHelper
    {
        //private readonly JsonSerializerOptions _options;

        public async Task<string> Post(string url, string value)
        {


            var client = new HttpClient();


            client.BaseAddress = new Uri("https://hirkansolar.ir/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            var newValue = JsonConvert.DeserializeObject(value);


            try
            {


                var response = await client.PostAsJsonAsync(url, newValue);
                var content = await response.Content.ReadAsStringAsync();


                return content;



            }
            catch (Exception ex)
            {

                throw ex;
            }




        }



    }


    public struct TransactionType
    {

        public const string Purchase = "Purchase";
        public const string Bill = "Bill";
        public const string SpecialBill = "SpecialBill";
    }








    public static class CreateJsonRequest
    {

        /// static CreateJasonRequest method goes here 

        public static string CreateJasonRequest(string terminalId, string acceptorId, long amount, string revertUri, string passPhrase,
         string requestId, string paymentId, string cmsPreservationId, string transactionType, BillInfo billInfo, List<MultiplexParameter> multiplexParameters)
        {

            try
            {


                RequestClass requestClass = new RequestClass();
                requestClass.Request.CmsPreservationId = cmsPreservationId;
                requestClass.Request.AcceptorId = acceptorId;
                requestClass.Request.amount = amount;
                requestClass.Request.BillInfo = billInfo;
                requestClass.Request.multiplexParameters = multiplexParameters;
                requestClass.Request.RequestId = requestId;
                requestClass.Request.RevertUri = revertUri;
                requestClass.Request.terminalId = terminalId;
                requestClass.Request.RequestTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                requestClass.Request.transactionType = transactionType;

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return "";




        }


        public static string CreateJasonRequest(IPGDataModel iPGData)

        {


            RequestClass requestClass = new RequestClass();

            try
            {


                requestClass.Request.CmsPreservationId = iPGData.CmsPreservationId;

                requestClass.Request.AcceptorId = iPGData.AcceptorId;
                requestClass.Request.amount = iPGData.Amount;
                requestClass.Request.BillInfo = iPGData.BillInfo;
                requestClass.Request.multiplexParameters = iPGData.MultiplexParameters;
                requestClass.Request.PaymentId = iPGData.PaymentId;
                requestClass.Request.RequestId = iPGData.RequestId;
                requestClass.Request.RevertUri = iPGData.RevertURL;
                requestClass.Request.terminalId = iPGData.TreminalId;
                requestClass.Request.RequestTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                requestClass.Request.transactionType = iPGData.TransactionType;

                CreateAESCoding(requestClass, iPGData.RsaPublicKey, iPGData.PassPhrase, requestClass.Request.multiplexParameters == null ? false : true);

            }
            catch (Exception ex)
            {


                throw ex;
            }


            return JsonConvert.SerializeObject(requestClass);


        }


        private static void CreateAESCoding(RequestClass requestClass, string rsaPublicKey, string passPhrase, bool isMultiplex)
        {


            try
            {

                string baseString =
                requestClass.Request.terminalId +
                passPhrase +
                requestClass.Request.amount.ToString().PadLeft(12, '0') +
                (isMultiplex ? "01" : "00") +
                (isMultiplex ?
                requestClass.Request.multiplexParameters.Select(t => $"{t.Iban.Replace("IR", "2718")}{t.Amount.ToString().PadLeft(12, '0')}")
                .Aggregate((a, b) => $"{a}{b}")
                : string.Empty);
                using (Aes myAes = Aes.Create())
                {

                    myAes.KeySize = 128;
                    myAes.GenerateKey();
                    myAes.GenerateIV();
                    byte[] keyAes = myAes.Key;
                    byte[] ivAes = myAes.IV;

                    byte[] resultCoding = new byte[48];
                    byte[] baseStringbyte = baseString.HexStringToByteArray();

                    byte[] encrypted = EncryptStringToBytes_Aes(baseStringbyte, myAes.Key, myAes.IV);
                    byte[] hsahash = new SHA256CryptoServiceProvider().ComputeHash(encrypted);

                    resultCoding = CombinArray(keyAes, hsahash);

                    requestClass.AuthenticationEnvelope.Data = RSAEncription(resultCoding, rsaPublicKey).ByteArrayToHexString();
                    //  string decripte = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                    requestClass.AuthenticationEnvelope.Iv = ivAes.ByteArrayToHexString();




                };

            }
            catch (Exception ex)
            {


                throw ex;
            }




        }



        public static byte[] HexStringToByteArray(this string hexString)
        {

            return Enumerable.Range(0, hexString.Length)
                 .Where(x => x % 2 == 0)
                 .Select(x => Convert.ToByte(value: hexString.Substring(startIndex: x, length: 2), fromBase: 16))
                 .ToArray();

        }



        public static string ByteArrayToHexString(this byte[] bytes)
        {

            return (bytes.Select(t => t.ToString(format: "X2")).Aggregate((a, b) => $"{a}{b}"));
        }


        private static byte[] EncryptStringToBytes_Aes(byte[] plainText, byte[] Key, byte[] IV)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.KeySize = 128;
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                // Create the streams used for encryption.

            }

        }

        private static byte[] CombinArray(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Array.Copy(first, 0, bytes, 0, first.Length);
            Array.Copy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }

        private static byte[] RSAEncription(byte[] aesCodingResult, string publicKey)
        {
            //var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);

            var encryptEngine = new Pkcs1Encoding(new RsaEngine());

            using (var txtreader = new StringReader(publicKey))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                encryptEngine.Init(true, keyParameter);
            }

            return encryptEngine.ProcessBlock(aesCodingResult, 0, aesCodingResult.Length);
        }




    }


    public class RequestClass
    {

        public AuthenticationEnvelope AuthenticationEnvelope = new AuthenticationEnvelope();
        public Request Request = new Request();

    }

    public class MultiplexParameter
    {

        public string Iban { get; set; }

        public int Amount { get; set; }

    }

    public class TokenResult
    {

        TokenResult()
        {
            result = new Result();
        }

        public string responseCode { get; set; }
        public object description { get; set; }
        public bool status { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public Result()
        {
            billInfo = new BillInfo();
        }
        public string token { get; set; }
        public int initiateTimeStamp { get; set; }
        public int expiryTimeStamp { get; set; }
        public string transactionType { get; set; }
        public BillInfo billInfo { get; set; }


    }

    public class AuthenticationEnvelope
    {

        public string Data { get; set; }
        public string Iv { get; set; }

    }

    public class Request
    {

        public string AcceptorId { get; set; }
        public long amount { get; set; }
        public BillInfo BillInfo { get; set; }

        public string CmsPreservationId { get; set; }
        public List<MultiplexParameter> multiplexParameters { get; set; }
        public string PaymentId { get; set; }
        public string RequestId { get; set; }
        public long RequestTimestamp { get; set; }
        public string RevertUri { get; set; }
        public string terminalId { get; set; }
        public string transactionType { get; set; }
        public List<KeyValuePair<string, string>> additionalParameters { get; set; }

    }




    //------------------------verify---------------




    /// <summary>
    /// محتوای پیام پاسخ پرداخت به آدرس برگشت وبگاه پذیرنده
    /// </summary>
    public class RequestVerify
    {

        [DataMember]
        //شماره ترمینال
        public string terminalId { get; set; }

        [DataMember]
        //شماره ارجاع
        public string retrievalReferenceNumber { get; set; }

        [DataMember]
        //شماره سند/ پیگیری
        public string systemTraceAuditNumber { get; set; }

        [DataMember]
        //توکن
        public string tokenIdentity { get; set; }


        //[DataMember]
        ////شماره پذیرنده
        //public string acceptorId { get; set; }



        [DataMember]
        //مقدار
        public string Amount { get; set; }




        [DataMember]
        ////ریسپانس کد
        public string responseCode { get; set; }


    }


    // **
    public class ResultGatway
    {
        public ResultGatway()
        {
            resultJson = "not set yet";
            errorJson = "not set yet";
        }

        public static string resultJson { get; set; }
        public static string errorJson { get; set; }


        public string GetResult()
        {
            return resultJson.ToString();
        }

        public void SetResult(string result)
        {
            resultJson = result;
        }

    }
    // **



}
