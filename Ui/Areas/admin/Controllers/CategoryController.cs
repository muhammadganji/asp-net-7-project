using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Ui.Tools;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly FileManager _fileManager;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _fileManager = new FileManager(webHostEnvironment);
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            List<Category> model = _categoryService.GetAll().ToList();
            return View(model);
        }


        // GET: admin/Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {

                category.FileName = await _fileManager.Upload(category.ImageFile, category.Name);
                _categoryService.Add(category);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: admin/Category/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }


        // GET: admin/Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                Category model = _categoryService.GetById(id);
                return View(model);
            }
            else
                return RedirectToAction("Index");
            
        }

        // POST: admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ImageFile != null)
                {
                    Category temp = _categoryService.GetById(category.Id);
                    if (temp != null)
                    {
                        _fileManager.Delete(temp.FileName);
                        category.FileName = await _fileManager.Upload(category.ImageFile, category.Name);
                    }
                }
                _categoryService.Update(category);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: admin/Category/Delete/5
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                Category model = _categoryService.GetById(id);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Category temp = _categoryService.GetById(id);
            if (temp != null)
            {
                _fileManager.Delete(temp.FileName);
                _categoryService.Remove(id);
            }
            return RedirectToAction("Index");
        }

    }
}
