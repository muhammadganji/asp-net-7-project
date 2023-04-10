using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ui.Tools;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }


        // GET: ArticleController
        public ActionResult Index()
        {
            List<Article> model = _articleService.GetAll().ToList();
            return View(model);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            DateTimePersian dt = new DateTimePersian();
            article.DateTimeCreated = dt.GetDateTimeIR();
            article.UserId = _userManager.GetUserId(User);

            _articleService.Add(article);
            return RedirectToAction("Index");
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            Article model = _articleService.GetById(id);
            return View(model);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Article article)
        {
            if (ModelState.IsValid)
            {
                _articleService.Update(article);
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Article article = _articleService.GetById(id);
            return View(article);
        }


        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection values)
        {
            _articleService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
