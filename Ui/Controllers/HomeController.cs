using DAL.Servieces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ui.Models;

namespace Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        private readonly ICommentService _comment;

        public HomeController(ILogger<HomeController> logger,
            IProductService product,
            ICategoryService category,
            ICommentService comment)
        {
            _logger = logger;
            _product = product;
            _category = category;
            _comment = comment;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.LastProducts = _product.GetLastAdded().ToList();
            model.Categorys = _category.GetAll().ToList();
            model.SliderProducts = _product.GetSliderProducts().ToList();

            // send count product to cart
            if (Request.Cookies["_product"] != null)
            {
                string cookiecontent = Request.Cookies["_product"].ToString();
                int countItem = cookiecontent.Split(",").Where(c => c != "").Count();
                ViewBag.countItem = countItem;
            }
            else
            {
                ViewBag.countItem = 0;
            }

            return View(model);
        }

        public IActionResult Search(string keyword)
        {
            SearchViewModel model = new SearchViewModel();
            model.Products = _product.GetByName(keyword).ToList();
            model.Categories = _category.GetAll().ToList();

            ViewBag.keyword = keyword;
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}