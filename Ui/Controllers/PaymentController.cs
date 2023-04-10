using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Ui.Models;
using Ui.Tools;

namespace Ui.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IOrderService _orderService;
        private readonly IProductOrderService _productOrderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderPaidService _orderPaidService;
        private readonly IProductOrderPaidService _productOrderPaidService;

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IArchiveService _archiveService;
        private readonly ICommentService _commentService;
        private readonly IFeatureService _featureService;
        private readonly IUserService _userService;
        private readonly SettingXML _setting;
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// شناسه سفارشی که وضعیت سفارش 
        /// را بعد از تاییدیه 
        /// به پرداخت شده تغییر خواهد داد
        /// </summary>
        private static int _OrderId = -1;
        /// <summary>
        /// جمع کل
        /// </summary>
        private static ulong _Amount = 0;

        public static string _userId;


        public PaymentController(IProductOrderPaidService productOrderPaidService, IOrderPaidService orderPaidService, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IProductOrderService productOrderService, IOrderService orderService, IProductService productService, ICategoryService categoryService, IArchiveService archiveService, ICommentService commentService, IFeatureService featureService, UserManager<AppUser> userManager, IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _archiveService = archiveService;
            _commentService = commentService;
            _featureService = featureService;
            _userManager = userManager;
            _userService = userService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _orderService = orderService;
            _productService = productService;
            _productOrderService = productOrderService;
            _setting = new SettingXML();
            _httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        public IActionResult Payment(int id)
        {
            // check order
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return RedirectToAction("ShowCart", "Product");
            }

            PaymentGetwayViewModel model = new PaymentGetwayViewModel();

            // check stock and maxStock
            List<ProductOrder> productsOrders = _productOrderService.GetByOrderId(id).ToList();

            if (productsOrders != null)
            {
                foreach (var productOrder in productsOrders)
                {
                    Product product = _productService.GetById(productOrder.ProductId);
                    if (product != null)
                    {
                        if (product.Stock < productOrder.Quantity)
                        {
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // بعدا تکمیل بشه،‌-------------------صفحه ی خطا ایجاد و قابل استفاده برای نمایش پیغام خطا
                            // show error, Because of not enugh Stock
                            return NotFound("موجودی کالا کافی نیست");
                        }
                    }
                }
            }

            DateTimePersian dtPersian = new DateTimePersian();

            model.Amount = GetAmountOfOrder(id);
            model.DateTime = dtPersian.GetDateTimeIR();
            model.Id = id;

            // save for later
            _OrderId = order.Id;
            _Amount = model.Amount;

            return View(model);
        }

        private ulong GetAmountOfOrder(int id)
        {
            List<ProductOrder> productOrders = _productOrderService.GetByOrderId(id).ToList();
            string ids = "";
            foreach (ProductOrder productOrder in productOrders) { ids = ids + productOrder.ProductId + ","; }
            ids = ids.Substring(0, ids.Length - 1);
            List<Product> products = _productService.GetByListProductId(ids).ToList();
            ulong total = 0;
            ulong row = 0;
            foreach (Product product in products)
            {
                row = product.Price * productOrders.Where(po => po.ProductId == product.Id).FirstOrDefault().Quantity;
                total = total + row;
            }
            return total;

        }

        /// <summary>
        /// بررسی موجودی کالا
        /// اگر در لحظه ای که قصد پرداخت رو داشتیم
        /// موجودی کافی نبود، به کاربر هشدار بده
        /// </summary>
        /// <param name="id">شناسه سفارش فاکتور</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public IActionResult CheckStockOfInvice(int OrderId)
        {
            string message = "";
            bool success = false;
            // check Stock of products in invoice
            var productsOrder = _productOrderService.GetByOrderId(OrderId).ToList();
            if (productsOrder != null)
            {
                foreach (var productOrder in productsOrder)
                {
                    var product = _productService.GetById(productOrder.ProductId);
                    if (product != null)
                    {
                        if (product.Stock < productOrder.Quantity)
                        {
                            message += " موجودی محصول " + product.Name + " کافی نیست :::: ";
                            success = true;
                        }
                    }
                }
            }

            if (success)
            {
                return Json(new { success = false, message = message });
            }
            return Json(new { success = true, message = "" });
        }


        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetDataCart(
            [FromBody] List<Product> listProduct)
        {
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------
            //------------ در حال انجام-----------

            // ایجاد ممنوعیت ثبت سفارس در دو حالت
            // 1. کافی نبودن موجودی کالا
            // 2. رعایت نکردن حداکثر  سقف خرید مجاز از هر کالا


            // if stock and maxStock Pass Ok

            // check Stock and maxStock of product
            string ErrorMessage = "";
            bool Success = true;
            foreach (var product in listProduct)
            {


                var p = _productService.GetById(product.Id);
                if (p != null)
                {
                    //if(p.MaxStock >= product.Stock)
                    if (p.MaxStock < product.Quantity)
                    {
                        // اگر درخواست از سقف سفارش بیشتر باشد
                        Success = false;
                        ErrorMessage = "تعداد درخواست شما در محصول " + p.Name + " بیشتر از سقف تعیین شده است \n ";

                    }
                    //if(p.Stock >= product.Stock)
                    if (p.Stock < product.Quantity)
                    {
                        // اگر درخواست از موجودی بیشتر باشد
                        Success = false;
                        ErrorMessage += "  ::::  موجودی سفارش محصول " + p.Name + " کمتر از درخواست شماست";
                    }


                }
            }
            if (!Success)
            {
                return Json(new { success = false, message = ErrorMessage });
            }
            // --------------




            //..........


            //-----------ثبت سفارش در حافظه
            // date IR
            DateTimePersian dateTimePersian = new DateTimePersian();
            StatusOrder statusOrder = new StatusOrder();
            string userName = _userManager.GetUserName(User);
            AppUser user = _userService.GetByUserName(userName); //_context.Users.Where(u => u.UserName == userName).FirstOrDefault();


            Order order = new Order();

            order.DateOrder = dateTimePersian.GetDateIR();
            order.StatusOrder = StatusOrder.InCart;
            order.UserId = user.Id;
            order.Description = "پرداخت نشده";

            _orderService.Add(order);

            ProductOrder productOrder = new ProductOrder();
            foreach (var product in listProduct)
            {
                productOrder = new ProductOrder();
                productOrder.OrderId = order.Id;
                productOrder.ProductId = product.Id;
                productOrder.Quantity = (uint)product.Quantity;
                _productOrderService.Add(productOrder);
            }
            // ثبت سفارش کامل شد -------

            // ----------حذف از سبد خرید

            if (Request.Cookies["_product"] != null)
            {
                Response.Cookies.Delete("_product");
            }


            // ---------- انتقال به صفحه پرداخت------>>>> بعد از اون انتقال به درگاه

            //return RedirectToAction("ActionOrViewName", "ControllerName");

            // I will handle it with JavaScript
            //return RedirectToAction("Payment", "Payment", new { IdOrder = order.IdOrder });

            // ready to paymant money
            //return Json(new { message = order.IdOrder });


            //return Ok(order.IdOrder);
            return Json(new { success = true, message = "", idOrder = order.Id });
        }



        [HttpPost]
        public async Task<IActionResult> PaymentGatway(int id)
        {

            // -----------------make ready Gatway IPG-----------------

            IPGDataModel IPGInfo = GetData();
            IPGInfo.Amount = (long)(_Amount * 10); // Rial
            IPGInfo.CmsPreservationId = (_userManager.GetUserName(User)).Substring(1); // phoneNumber of customer
            IranKishPayment iranKishPayment = new IranKishPayment();

            try
            {
                // **
                ResultGatway resultJson = new ResultGatway();
                // get username for save in table orderPaid
                _userId = _userManager.GetUserId(User);

                // **

                await iranKishPayment.getToken(IPGInfo, HttpContext);
                if (!ModelState.IsValid)
                {

                    return BadRequest("Enter required fields");
                }

                // **
                return this.Ok($"Form Data received! \n result json: " + resultJson.GetResult());
                // **

                //return this.Ok($"Form Data received!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            // -----------------make ready Gatway IPG-------------------
            //return View();
        }

        /// <summary>
        /// خواندن اطلاعات درگاه از طریق فایل تنظیمات
        /// </summary>
        /// <returns>اطلاعات درگاه</returns>
        public IPGDataModel GetData()
        {
            AssignXml obj = new AssignXml();
            var data = obj.GetLoad();
            return (data);
        }



        /// <summary>
        /// تلاش دوم
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Verify()
        {
            // تایید تراکنش
            // ذخیره اطلاعات تراکنش
            // ذخیره اطلاعات محصولات
            // کسر از آمار موجودی کالا ------ درحال انجام


            RequestVerify requestVerify = new RequestVerify();
            IranKishVerify iranKishVerify = new IranKishVerify();

            try
            {






                //شماره ترمینال 
                requestVerify.terminalId = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["acceptorId"].ToString().Substring(7, 8);


                //مقدار
                requestVerify.Amount = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["Amount"];

                //شماره ارجاع 
                requestVerify.retrievalReferenceNumber = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["retrievalReferenceNumber"];

                //توکن
                requestVerify.tokenIdentity = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["token"];

                // شماره سند/ پیگیری
                requestVerify.systemTraceAuditNumber = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["systemTraceAuditNumber"];


                //ریسپانس کد
                requestVerify.responseCode = _httpContextAccessor.HttpContext.Response.HttpContext.Request.Form["responseCode"];

                //return View(requestVerify);


            }
            catch
            {
                // save log -- Please do it later ;)

            }






            string response = "";
            try
            {


                if (!string.IsNullOrEmpty(requestVerify.responseCode) && requestVerify.responseCode == "00")
                {



                    response = await iranKishVerify.Verification(requestVerify);

                    // ذخیره اطلاعات پرداخت
                    if (response != null)
                    {
                        // ::::::::::::::  1   :::::::::::::::::::
                        // save header of invoice
                        OrderPaid orderPaid = new OrderPaid();
                        DateTimePersian dt = new DateTimePersian();

                        orderPaid.DateTimeIR = dt.GetDateTimeIR();
                        orderPaid.Token = requestVerify.tokenIdentity;
                        orderPaid.RetrievalReferenceNumber = requestVerify.retrievalReferenceNumber;
                        orderPaid.ResponseCode = requestVerify.responseCode;
                        orderPaid.Amount = requestVerify.Amount;
                        orderPaid.SystemTranceAuditNumber = requestVerify.systemTraceAuditNumber;
                        orderPaid.StatusOrder = StatusOrder.Paid;

                        orderPaid.UserId= _userId; //_userManager.GetUserName(User);
                        _orderPaidService.Add(orderPaid);

                        // save products of invoice

                        var listProductOrder = _productOrderService.GetByOrderId(_OrderId); //_context.productOrders.Where(po => po.IdOrder == _OrderId).ToList();
                        if (listProductOrder != null)
                        {
                            List<ProductOrderPaid> ListproductsOrderPaid = new List<ProductOrderPaid>();

                            // لیست محصولات برای بروز رسانی آمار
                            List<Product> listProducts = new List<Product>();
                            foreach (var productOrder in listProductOrder)
                            {
                                Product product = new Product();

                                product = _productService.GetById(productOrder.ProductId); //_context.products.Where(p => p.IdProduct == productOrder.IdProduct).FirstOrDefault();

                                ListproductsOrderPaid.Add(new ProductOrderPaid
                                {
                                    ProductId = product.Id,
                                    OrderPaidId = orderPaid.Id,
                                    Price = product.Price,
                                    Quantity = productOrder.Quantity

                                });

                                product.Stock = product.Stock - productOrder.Quantity;
                                listProducts.Add(product);


                            }

                            // ثبت آمار سفارش پرداخت
                            _productOrderPaidService.AddRange(ListproductsOrderPaid);
                            //_context.productOrderPaid.AddRange(ListproductsOrderPaid);
                            // کسر از آمار
                            _productService.UpdateRange(listProducts);
                            //_context.products.UpdateRange(listProducts);
                            //_context.SaveChanges();



                            // ::::::::::::::  2  :::::::::::::::::::
                            // remove products of order ::::: scenario changed --> just status update
                            var tempOrder = _orderService.GetById(_OrderId); //_context.orders.Where(o => o.IdOrder == _OrderId).FirstOrDefault();
                            if (tempOrder != null)
                            {
                                //List<ProductOrder> lsProductsOrder = new List<ProductOrder>();
                                //lsProductsOrder = _context.productOrders.Where(pr => pr.IdOrder == _OrderId).ToList();
                                //_context.productOrders.RemoveRange(lsProductsOrder);
                                //_context.SaveChanges();

                                //_context.orders.Remove(tempOrder);

                                tempOrder.StatusOrder = StatusOrder.Paid;
                                _orderService.Update(tempOrder);
                                //_context.orders.Update(tempOrder);
                                //_context.SaveChanges();

                            }
                        }


                        // ::::::::::::::   3   :::::::::::::::::::
                        // Send Alaram for Admin
                        MessageSms message = new MessageSms();
                        await message.SendAlarmAdmin(orderPaid.Amount);
                        await message.SendAlarmBackup(orderPaid.Amount);



                    }

                    //==============***********

                    ViewBag.response = response;


                }

                else
                {


                    response = await iranKishVerify.Verification(requestVerify);
                    ViewBag.response = response;

                }





            }
            catch (System.Exception ex)
            {



                throw ex;



            }




            return View();
        }




    }
}
