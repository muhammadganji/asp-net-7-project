using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Areas.admin.Models;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IOrderPaidService _orderPaidService;
        private readonly IUserService _userService;
        private readonly IProductOrderPaidService _productOrderPaidService;
        private readonly IProductService _productService;
        public OrderController(IOrderPaidService orderPaidService, IUserService userService, IProductOrderPaidService productOrderPaidService, IProductService productService)
        {
            _orderPaidService = orderPaidService;
            _userService = userService;
            _productOrderPaidService = productOrderPaidService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            List<OrderPaid> model = _orderPaidService.GetAll().ToList();
            model.ForEach(o => { o.user = _userService.GetById(o.UserId); });
            model.ForEach(o => { o.UserId = string.Join(" ", o.user.FirstName, o.user.LastName); });
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
                return View("NotFound");
            ProductOrderPaidViewModel model = new ProductOrderPaidViewModel();
            model.orderPaid = _orderPaidService.GetById((int)id);
            model.productOrderPaids = _productOrderPaidService.GetByOrderPaidId((int)id).ToList();
            model.orderPaid.user = _userService.GetById(model.orderPaid.UserId);
            model.productOrderPaids.ForEach(op => { op.product = _productService.GetById(op.ProductId); });

            return View(model);

            //OrderPaid model = _orderPaidService.GetById(id);

            //OrderPaid tempOrder = _dbcontex.orderPaids.Where(op => op.IdOrderPaid == id).FirstOrDefault();
            //if (tempOrder != null)
            //{
            //    ProductOfOrderPaidViewModel model = new ProductOfOrderPaidViewModel();

            //    //  header of invoice
            //    model.orderPaid = tempOrder;
            //    var user = _dbcontex.Users.Where(u => u.UserName == model.orderPaid.Username).FirstOrDefault();
            //    if (user != null)
            //    {
            //        model.Address = user.Address;
            //        model.Zipcode = user.PostCode;
            //        model.FullName = string.Join(" ", user.FirstName, user.LastName);
            //        model.PhoneNumber = user.PhoneNumber;
            //    }
            //    // get products info
            //    var tempProduct = _dbcontex.productOrderPaid.Where(
            //        po => po.IdOrderPaid == tempOrder.IdOrderPaid).ToList();

            //    foreach (var item in tempProduct)
            //    {
            //        Product p = new Product();
            //        p = _dbcontex.products.Where(p => p.IdProduct == item.IdProduct).FirstOrDefault();
            //        model.ListProductOrderPaid.Add(new Models.ViewModels.ProductOrderPaid
            //        {
            //            IdProduct = item.IdProduct,
            //            Descroption = p.Description,
            //            ImageName = p.ImageName,
            //            NameProduct = p.NameProduct,
            //            Price = item.Price,
            //            QuantityProduct = item.QuantityProduct
            //        });
            //    }
            //    return View(model);
            //}
            //else
            //{
            //    return NotFound();
            //}

        }
    }
}
