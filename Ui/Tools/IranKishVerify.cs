using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Xml;

namespace Ui.Tools
{
    public class IranKishVerify
    {


        public async Task<string> Verification(RequestVerify requestVerify)
        {

            string result = "";

            var client = new HttpClient();

            try
            {

                string request = JsonConvert.SerializeObject(requestVerify);
                var newrequest = JsonConvert.DeserializeObject(request);
                XmlDocument doc = new XmlDocument();
                doc.Load("DataXMLFile.xml");
                string url = doc.SelectNodes("DocumentElement/BaseAddress/verify")[0].InnerXml.ToString();


                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                var response = await client.PostAsJsonAsync(url, newrequest);
                var content = await response.Content.ReadAsStringAsync();


                if (content != null)
                {

                    VerifyResult jResult = JsonConvert.DeserializeObject<VerifyResult>(content);


                    if (jResult.status)
                    {

                        //result = "عملیات تایید تراکنش با موفقیت انجام شد";
                        result = "عملیات تایید تراکنش با موفقیت انجام شد" +
                            "\n responseCode:  " + jResult.responseCode +
                            "\n description:  " + jResult.description;


                        #region comment

                        /*
                        // save invoice and products of order
                        ///----------------------------------------------------SAVE in Database
                        // we use _IdOrder to save Products of orders

                        // 1. save order paid
                        // 2. delete order


                        // ::::::::::::::  1   :::::::::::::::::::
                        // save header of invoice
                        OrderPaid orderPaid = new OrderPaid();
                        DateTimePersian dt = new DateTimePersian();

                        orderPaid.Username = _username;
                        orderPaid.DateTimeIR = dt.GetDateTimeIR();
                        orderPaid.Token = requestVerify.tokenIdentity;
                        orderPaid.RetrievalReferenceNumber = requestVerify.retrievalReferenceNumber;
                        orderPaid.ResponseCode = requestVerify.responseCode;
                        orderPaid.Amount = requestVerify.Amount;
                        orderPaid.SystemTranceAuditNumber = requestVerify.systemTraceAuditNumber;


                        _context.orderPaids.Add(orderPaid);
                        _context.SaveChanges();




                        // save products of invoice
                        var listProductOrder = _context.productOrders.Where(po => po.IdOrder == _IdOrder);

                        if (listProductOrder != null)
                        {
                            List<ProductOrderPaid> ListproductsOrderPaid = new List<ProductOrderPaid>();


                            foreach (var productOrder in listProductOrder)
                            {
                                Product product = new Product();
                                // Error !
                                product = _context.products.Where(p =>
                                p.IdProduct == productOrder.IdProduct).FirstOrDefault();
                                ListproductsOrderPaid.Add(new ProductOrderPaid
                                {
                                    IdProduct = product.IdProduct,
                                    IdOrderPaid = orderPaid.IdOrderPaid,
                                    Price = product.Price,
                                    QuantityProduct = productOrder.Quantity

                                });


                            }

                            _context.productOrderPaid.AddRange(ListproductsOrderPaid);
                            _context.SaveChanges();


                            // ::::::::::::::  2  :::::::::::::::::::
                            // remove products of order
                            var tempOrder = _context.orders.Where(o => o.IdOrder == _IdOrder).FirstOrDefault();
                            if (tempOrder != null)
                            {
                                List<ProductOrder> lsProductsOrder = new List<ProductOrder>();
                                lsProductsOrder = _context.productOrders.Where(pr => pr.IdOrder == _IdOrder).ToList();
                                _context.productOrders.RemoveRange(lsProductsOrder);
                                _context.SaveChanges();

                                _context.orders.Remove(tempOrder);
                                _context.SaveChanges();
                            }


                        }
                        else
                        {

                        }
                        */
                        #endregion


                        ///-----------------------------------------------------------END
                    }
                    else
                    {

                        //result = "عملیات تایید تراکنش با موفقیت انجام نشد ";
                        result = "عملیات تایید تراکنش با موفقیت انجام نشد " +
                            "\n --responseCode:  " + jResult.responseCode +
                            "\n --description:  " + jResult.description;



                    }



                }


            }
            catch (Exception ex)
            {

                result = ex + "خطا";
            }


            return result;


        }



        /// <summary>
        /// محتوی پیام پاسخ در سرویس ارسال تاییدیه
        /// </summary>
        public class VerifyResult
        {
            public string responseCode { get; set; }
            public string description { get; set; }
            public bool status { get; set; }
            public SubResult result { get; set; }



        }



        public class SubResult
        {

            public string responseCode { get; set; }
            public string systemTraceAuditNumber { get; set; }
            public string retrievalReferenceNumber { get; set; }
            public DateTime transactionDateTime { get; set; }
            public int transactionDate { get; set; }
            public int transactionTime { get; set; }
            public string processCode { get; set; }
            public object requestId { get; set; }
            public object additional { get; set; }
            public object billType { get; set; }
            public object billId { get; set; }
            public string paymentId { get; set; }
            public string amount { get; set; }
            public object revertUri { get; set; }
            public object acceptorId { get; set; }
            public object terminalId { get; set; }
            public object tokenIdentity { get; set; }




        }




    }
}
