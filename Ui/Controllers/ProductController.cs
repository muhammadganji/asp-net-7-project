using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Ui.Models;
using Ui.Tools;

namespace Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IArchiveService _archiveService;
        private readonly ICommentService _commentService;
        private readonly IFeatureService _featureService;
        private readonly IUserService _userService;
        private readonly SettingXML _setting;
        private readonly UserManager<AppUser> _userManager;


        public ProductController(IProductService productService, ICategoryService categoryService, IArchiveService archiveService, ICommentService commentService, IFeatureService featureService, UserManager<AppUser> userManager, IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _archiveService = archiveService;
            _commentService = commentService;
            _featureService = featureService;
            _userManager = userManager;
            _userService = userService;

            _setting = new SettingXML();
        }

        public IActionResult ShowDetails(int Id)
        {
            if (Id == 0)
                return RedirectToAction(actionName: "Index", controllerName: "Home");

            ProductViewModel model = new ProductViewModel();
            model.Product = _productService.GetById(Id);
            model.Categories = _categoryService.GetAll().ToList();
            model.Archives = _archiveService.GetByProductId(Id).ToList();
            model.Comments = _commentService.GetByProductId(Id).ToList();
            model.Features = _featureService.GetByProductId(Id);
            model.SameProducts = _productService.GetSameProducts(model.Product.CategoryId).ToList();
            string userId = _userManager.GetUserId(User);
            ViewBag.HasWrittenComment = _commentService.HasWrittenComment(userId, Id); // sign in + has no any comment

            return View(model);
        }

        public IActionResult ShowCategories(int Id)
        {
            CategoryOfProductViewModel model = new CategoryOfProductViewModel();
            model.Categories = _categoryService.GetAll().ToList();
            model.Products = _productService.GetByCategory(Id).ToList();
            model.CategoryName = _categoryService.GetById(Id).Name;
            model.ImageName = _categoryService.GetById(Id).FileName;

            return View(model);
        }

        public IActionResult ShowCart()
        {

            ProductCartViewModel model = new ProductCartViewModel();
            model.Categories = _categoryService.GetAll().ToList();
            if (Request.Cookies["_product"] != null)
            {
                // Ids :::    2,3,4,5,
                string cookeisProductId = Request.Cookies["_product"].ToString();
                if (cookeisProductId != null && cookeisProductId != string.Empty)
                {
                    cookeisProductId = cookeisProductId.Substring(0, cookeisProductId.Length - 1);
                    model.Products = _productService.GetByListProductId(cookeisProductId).ToList();
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                // check exist cookies
                if (Request.Cookies["_product"] == null)
                {
                    Response.Cookies.Append("_product", id + ",", new CookieOptions()
                    {
                        Expires = DateTime.Now.AddMinutes(_setting.TimeExpiresForCookeis)
                    });
                    return Json(new { statue = "success", message = "در لیست افزوده شد", basket_count = 1 });
                }
                else
                {
                    string cookiecontent = Request.Cookies["_product"].ToString();
                    // exist in list
                    if (cookiecontent.Contains(id + ",") == true)
                    {
                        int countItem = cookiecontent.Split(",").Where(c => c != "").Count();
                        return Json(new { statue = "exist", message = "این محصول در لیست شما وجود دارد", basket_count = countItem });
                    }
                    else
                    {
                        // not exist in list
                        cookiecontent += id + ",";
                        Response.Cookies.Append("_product", cookiecontent, new CookieOptions()
                        {
                            Expires = DateTime.Now.AddMinutes(_setting.TimeExpiresForCookeis)
                        });
                        int count_item = cookiecontent.Split(",").Where(r => r != "").Count();
                        string[] list_id = cookiecontent.Split(",").Where(r => r != "").ToArray();
                        return Json(new { statue = "success", message = "در لیست افزوده شد", basket_count = count_item });
                    }


                }
            }
            else
            {
                return Json(new { status = "fail", message = "این محصول یافت نشد" });
            }

        }

        [HttpGet]
        public IActionResult DeleteFromCart(int? id)
        {
            // send count product to cart
            if (Request.Cookies["_product"] != null)
            {
                string cookiecontent = Request.Cookies["_product"].ToString();
                List<string> listId = cookiecontent.Split(",").Where(c => c != "").ToList();
                // remove currnet list id
                listId.Remove(id.ToString());
                // clear coockies _product
                Response.Cookies.Delete("_product");
                if (listId.Count == 0)
                {
                    return RedirectToAction("ShowCart");
                }
                string cookeisProductId = "";
                // try to add other id
                foreach (var IdProduct in listId)
                {
                    cookeisProductId += cookeisProductId + IdProduct + ",";
                }
                if (cookeisProductId != null && cookeisProductId != string.Empty)
                {
                    Response.Cookies.Append("_product", cookeisProductId, new Microsoft.AspNetCore.Http.CookieOptions()
                    {
                        Expires = DateTime.Now.AddMinutes(45)
                    });
                }

                return RedirectToAction("ShowCart");
            }
            else
            { ViewBag.countItem = 0; }

            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowInvoice()
        {
            InvoiceViewModel model = new InvoiceViewModel();
            model.Categories = _categoryService.GetAll().ToList();

            string userId = _userManager.GetUserId(User);
            model.UserInfo = _userService.GetById(userId);
            model.CompanyInfo = new AppUser
            {
                FirstName = _setting.Name,
                Address = _setting.Address,
                Zipcode = _setting.Zipcode,
                PhoneNumber = _setting.Phone
            };

            if (Request.Cookies["_product"] != null)
            {
                // Ids :::    2,3,4,5,
                string cookeisProductId = Request.Cookies["_product"].ToString();
                if (cookeisProductId != null && cookeisProductId != string.Empty)
                {
                    cookeisProductId = cookeisProductId.Substring(0, cookeisProductId.Length - 1);
                    model.Products = _productService.GetByListProductId(cookeisProductId).ToList();
                }
            }
            DateTimePersian dt = new DateTimePersian();
            model.DateTimeCreateIR = dt.GetDateIR();

            return View(model);
        }

        #region comment
        //[Authorize(Roles = "user")]
        [Authorize(Roles = "admin,user")]
        public IActionResult saveComment(int id, string TextComment)
        {
            try
            {

                if (id == null || id == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                Comment model = new Comment();
                DateTimePersian dt = new DateTimePersian();
                string userId = _userManager.GetUserId(User);
                AppUser user = _userService.GetById(userId);
                model.FullName = user.FirstName + " " + user.LastName;
                model.UserId = _userManager.GetUserId(User);
                model.ProductId = id;
                model.TextComment = TextComment;
                model.TimeStampIR = dt.GetDateTimeIR();
                _commentService.Add(model);

                return RedirectToAction(actionName: "ShowDetails", new {Id = model.ProductId});
            }
            catch
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }


        #endregion



    }
}
