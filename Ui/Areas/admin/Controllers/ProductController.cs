using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph;
using System.Data;
using Ui.Areas.admin.Models;
using Ui.Tools;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IFeatureService _featureService;
        private readonly IArchiveService _archiveService;
        private readonly FileManager _fileManager;

        /// <summary>
        /// for Archive (DeleteArchive)
        /// </summary>
        //public static int _productId_for_Archive = 0;
        /// <summary>
        /// برای کار با محصول و ویژگی
        /// </summary>
        //private static int _productId = 0;

        /// <summary>
        /// برای نمایش درست گروه بندی محصولات
        /// در پنل ادمین
        /// </summary>
        //public static int _categoryId { get; set; } = -1;

        public ProductController(IProductService productService, IFeatureService featureService, ICategoryService categoryService, IArchiveService archiveService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _featureService = featureService;
            _archiveService = archiveService;
            _fileManager = new FileManager(webHostEnvironment);
        }


        public IActionResult Index(int? categoryId)
        {
            // clear list
            ProductViewModel model = new ProductViewModel();
            if (categoryId != null || categoryId == 0)
            {
                model.Categories = _categoryService.GetAll().ToList();
                if (model.Categories != null)
                {
                    model.Products = _productService.GetByCategory((int)categoryId).ToList();
                    ViewBag.IdCategory = (int)categoryId;
                }
                return View(model);
            }
            else
            {
                model.Categories = _categoryService.GetAll().ToList();
                model.Products = _productService.GetByCategory(model.Categories[0].Id).ToList();
                ViewBag.IdCategory = model.Categories[0].Id;
                return View(model);
                //model.Categories = _categoryService.GetAll().ToList();
                //if (_categoryId != -1)
                //{
                //    model.Products = _productService.GetByCategory(_categoryId).ToList();
                //    ViewBag.IdCategory = _categoryId;
                //}
                //else
                //{
                //    _categoryId = model.Categories.FirstOrDefault().Id;
                //    model.Products = _productService.GetByCategory(_categoryId).ToList() ?? new List<Entities.Product>();
                //    ViewBag.IdCategory = _categoryId;
                //}
                //return View(model);
            }
        }

        #region Feature

        // GET: admin/Product/Details/5


        // POST: admin/Product/CreateFeature/...
        //public async Task<IActionResult> CreateFeature(ProductViewModel feature)
        [HttpPost]
        public IActionResult CreateFeature(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _featureService.Add(feature);
                return RedirectToAction("Details", new { productId = feature.ProductId });
                ////Feature f = new Feature
                ////{
                ////    TitleFeature = feature.TitleFeature,
                ////    ValueFeature = feature.ValueFeature,
                ////    IdProduct = _idProduct
                ////};
                ////_context.features.Add(f);
                ////await _context.SaveChangesAsync();

                ////------------
                //// 1. check id
                //// 2. get product
                //// 3. get feature

                //// 1
                //if (_productId == 0)
                //{
                //    return View("NotFound");
                //}
                //// 2
                //Product p = _context.products.Where(p => p.IdProduct == _idProduct).FirstOrDefault();
                //if (p == null)
                //{
                //    return View("NotFound");
                //    //return NotFound();
                //}
                //_idProduct = p.IdProduct;
                //string categoryname = _context.categories.Where(c => c.IdCategory == p.IdCategory).FirstOrDefault().NameCategory;
                //ProductViewModel product = new ProductViewModel
                //{
                //    IdProduct = p.IdProduct,
                //    NameProduct = p.NameProduct,
                //    Description = p.Description,
                //    // DescriptionCompletely = p.DescriptionCompletely,
                //    ImageName = p.ImageName,
                //    IdCategory = p.IdCategory,
                //    Price = p.Price,
                //    CategoryName = categoryname
                //};

                //// 3
                //List<Feature> features = await _context.features.Where(f => f.IdProduct == p.IdProduct).ToListAsync();
                //if (features != null)
                //{
                //    product.listFeature = features;
                //}

                ////return View(product);
                //return View("Details", product);
                ////------------
                ////await Details(_idProduct);

            }
            else
            {
                return View("Index");
            }
        }

        // POST: admin/Product/DeleteFeature/5
        // admin/Product/DeleteFeature/6
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("DeleteFeature")]
        public IActionResult DeleteFeature(int? id, int? productId)
        {
            _featureService.Remove((int)id);
            return RedirectToAction("Details", new { productId = productId });

            //var feature = await _context.features.FindAsync(id);
            //if (feature != null)
            //{
            //    _context.features.Remove(feature);
            //    await _context.SaveChangesAsync();
            //}

            ////------------
            //// 1. check id
            //// 2. get product
            //// 3. get feature

            //// 1
            //if (_idProduct == 0)
            //{
            //    return View("NotFound");
            //}
            //// 2
            //Product p = _context.products.Where(p => p.IdProduct == _idProduct).FirstOrDefault();
            //if (p == null)
            //{
            //    return View("NotFound");
            //}
            //_idProduct = p.IdProduct;
            //string categoryname = _context.categories.Where(c => c.IdCategory == p.IdCategory).FirstOrDefault().NameCategory;
            //ProductViewModel product = new ProductViewModel
            //{
            //    IdProduct = p.IdProduct,
            //    NameProduct = p.NameProduct,
            //    Description = p.Description,
            //    // DescriptionCompletely = p.DescriptionCompletely,
            //    ImageName = p.ImageName,
            //    IdCategory = p.IdCategory,
            //    Price = p.Price,
            //    CategoryName = categoryname
            //};

            //// 3
            //List<Feature> features = await _context.features.Where(f => f.IdProduct == p.IdProduct).ToListAsync();
            //if (features != null)
            //{
            //    product.listFeature = features;
            //}

            ////return View(product);
            //return View("Details", product);
            ////------------
        }

        #endregion

        #region Archive

        [HttpGet]
        public IActionResult Archive(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return View("NotFound");
            }
            ProductViewModel model = new ProductViewModel();
            model.product = _productService.GetById((int)productId);
            model.Archives = _archiveService.GetByProductId((int)productId).ToList();
            // get copy id for Detele
            //_productId_for_Archive = (int)productId;
            return View(model);

            //var product = _context.products.Where(p => p.IdProduct == id).FirstOrDefault();
            //if (product == null)
            //    return NotFound();

            //var listArchive = _context.archive.Where(a => a.IdProduct == id).ToList();
            //var model = new ArchiveViewModel
            //{
            //    product = product,
            //    listArchive = listArchive,
            //};



            //return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">productId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateArchive(Archive archive)
        {
            if (archive.ImageFile != null)
            {
                archive.ImageName = await _fileManager.Upload(archive.ImageFile, "");
            }
            _archiveService.Add(archive);
            return RedirectToAction("Archive", new { productId = (int)archive.ProductId });

            //// save and upload archive
            //DateTimePersian dt = new DateTimePersian();
            //string ImageName = UploadedFile(temp.ImageFile);
            //string DateTimeIR = dt.GetDateTimeIR();
            //Archive ar = new Archive
            //{
            //    DateTimeCreated = DateTimeIR,
            //    IdProduct = temp.product.IdProduct,
            //    ImageName = ImageName
            //};
            //_context.archive.Add(ar);
            //_context.SaveChanges();

            //// get list of image for archive
            //var product = _context.products.Where(p => p.IdProduct == temp.product.IdProduct).FirstOrDefault();
            //if (product == null)
            //    return NotFound();

            //var listArchive = _context.archive.Where(a => a.IdProduct == temp.product.IdProduct).ToList();
            //var model = new ArchiveViewModel
            //{
            //    product = product,
            //    listArchive = listArchive,
            //};



            //return View("Archive", model);
        }

        [HttpPost, ActionName("DeleteArchive")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteArchive(int? id, int? ProductId)
        {
            // 1. delete image
            // 2. remove archive
            // 3. reload page

            // 1
            if (id != null || id != 0)
            {
                Archive archive = _archiveService.GetById((int)id);
                if (archive != null)
                {
                    _fileManager.Delete(archive.ImageName);
                }
                _archiveService.Remove((int)id);
            }
            return RedirectToAction("Archive", new { productId = (int)ProductId });
            //var archive = await _context.archive.FindAsync(id);
            //if (DeleteFile(archive.ImageName))
            //{
            //    // successfully delete image
            //}
            //else
            //{
            //    // Faild to delete image
            //}

            //// 2.
            //_context.archive.Remove(archive);
            //await _context.SaveChangesAsync();

            //// 3.
            //// return RedirectToAction("Archive", _productId_for_Archive);
            //var product = _context.products.Where(p => p.IdProduct == _productId_for_Archive).FirstOrDefault();
            //if (product == null)
            //    return NotFound();

            //var listArchive = _context.archive.Where(a => a.IdProduct == _productId_for_Archive).ToList();
            //var model = new ArchiveViewModel
            //{
            //    product = product,
            //    listArchive = listArchive,
            //};
            //return View("Archive", model);

        }
        #endregion

        #region Create | Edit | Delete | Details

        [HttpGet]
        public async Task<IActionResult> Details(int? productId)
        {
            // 1. check id
            // 2. get product
            // 3. get feature

            ProductViewModel model = new ProductViewModel();
            // 1
            if (productId == null)
            {
                return View("NotFound");
                //return NotFound();
            }

            // 2
            model.product = _productService.GetById((int)productId);
            model.product.category = _categoryService.GetById(model.product.CategoryId);
            model.Features = _featureService.GetByProductId((int)productId).ToList();
            //_productId = (int)productId;
            return View(model);
            //Product p = _context.products.Where(p => p.IdProduct == id).FirstOrDefault();
            //model.Categories = _categoryService.GetAll().ToList();
            //if (p == null)
            //{
            //    return View("NotFound");
            //}
            //_idProduct = p.IdProduct;
            //string categoryname = "";
            //try
            //{
            //    categoryname = _context.categories.Where(c => c.IdCategory == p.IdCategory).FirstOrDefault().NameCategory;
            //}
            //catch
            //{
            //    // nothing
            //}
            //ProductViewModel product = new ProductViewModel
            //{
            //    IdProduct = p.IdProduct,
            //    NameProduct = p.NameProduct,
            //    Description = p.Description,
            //    // DescriptionCompletely = p.DescriptionCompletely,
            //    ImageName = p.ImageName,
            //    IdCategory = p.IdCategory,
            //    Price = p.Price,
            //    CategoryName = categoryname
            //};

            // 3
            //List<Feature> features = new List<Feature>();
            //try
            //{
            //    features = await _context.features.Where(f => f.IdProduct == p.IdProduct).ToListAsync();
            //}
            //catch
            //{

            //}
            //if (features != null)
            //{
            //    product.listFeature = features;
            //}


        }


        // GET: admin/Product/Create
        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            model.Categories = _categoryService.GetAll().ToList();
            return View(model);

            ////ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory");
            //var categories = _context.categories.ToList();
            //ProductViewModel model = new ProductViewModel
            //{
            //    listCategory = categories
            //};
            //return View(model);
            ////return View();
        }
        // POST: admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //([Bind("IdProduct,NameProduct,Description,ImageName,Price,IdCategory")] ProductViewModel product)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                    product.ImageName = await _fileManager.Upload(product.ImageFile, product.Name);
                _productService.Add(product);
                return RedirectToAction("Index");
                //string imageName = UploadedFile(product.ImageFile);
                //Product model = new Product
                //{
                //    NameProduct = product.NameProduct,
                //    Description = product.Description,
                //    DescriptionSecond = product.DescriptionSecond,
                //    Stock = product.Stock,
                //    MaxStock = product.MaxStock,
                //    IdCategory = product.IdCategory,
                //    Price = product.Price,
                //    ImageName = imageName,
                //};
                //_context.Add(model);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                ProductViewModel model = new ProductViewModel();
                model.Categories = _categoryService.GetAll().ToList();
                return View(model);
                //ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", product.IdCategory);
                //var categories = _context.categories.ToList();
                //ProductViewModel model = new ProductViewModel
                //{
                //    listCategory = categories
                //};
                //return View(model);
            }
            //return View(product);
        }

        // GET: admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            ProductViewModel model = new ProductViewModel();
            model.Categories = _categoryService.GetAll().ToList();
            model.product = _productService.GetById((int)id);
            return View(model);

            //var categories = _context.categories.ToList();
            //ProductViewModel product = new ProductViewModel
            //{
            //    listCategory = categories
            //};

            ////return View();

            //var prd = await _context.products.FindAsync(id);
            //if (prd == null)
            //{
            //    return View("NotFound");
            //}
            //product.IdProduct = prd.IdProduct;
            //product.NameProduct = prd.NameProduct;
            //product.IdCategory = prd.IdCategory;
            //product.Description = prd.Description;
            //product.DescriptionSecond = prd.DescriptionSecond;
            //product.Stock = prd.Stock;
            //product.MaxStock = prd.MaxStock;
            //product.Price = prd.Price;
            //product.ImageName = prd.ImageName;

            //ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", product.IdCategory);
            //return View(product);
        }

        // POST: admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //public async Task<IActionResult> Edit(int id, [Bind("IdProduct,NameProduct,Description,ImageName,Price,IdCategory")] Product product)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            // 1. check product
            // 2. check image (upload new or nothing)
            // 3. update parameter
            // 4. go to the list of product

            // 1
            if (id != product.Id)
            {
                return View("NotFound");
            }


            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    _fileManager.Delete(product.ImageName);
                    product.ImageName = await _fileManager.Upload(product.ImageFile, product.Name);
                }
                _productService.Update(product);
                return RedirectToAction("Index");
                //Product prd = new Product
                //{
                //    IdProduct = product.IdProduct,
                //    IdCategory = product.IdCategory,
                //    NameProduct = product.NameProduct,
                //    Description = product.Description,
                //    DescriptionSecond = product.DescriptionSecond,
                //    Stock = product.Stock,
                //    MaxStock = product.MaxStock,
                //    ImageName = product.ImageName,
                //    Price = product.Price,

                //};

                //if (product.ImageFile != null)
                //{
                //    // 2 : First upload new image, Seconde delete old image.

                //    // First
                //    prd.ImageName = UploadedFile(product.ImageFile);

                //    //Seconde
                //    if (DeleteFile(product.ImageName))
                //    {
                //        // Delete files Successfully
                //    }
                //    else
                //    {
                //        // Faild to delete files
                //    }

                //}

                //// 3
                //_context.products.Update(prd);
                //await _context.SaveChangesAsync();
            }
            else
            {
                ProductViewModel model = new ProductViewModel();
                model.Categories = _categoryService.GetAll().ToList();
                model.product = product;
                return View(model);
            }
            //ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", product.IdCategory);
            //    return View(product);
        }

        // GET: admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return View("NotFound");
            }
            ProductViewModel model = new ProductViewModel();
            model.Features = _featureService.GetByProductId((int)id).ToList();
            model.product = _productService.GetById((int)id);
            model.product.category = _categoryService.GetById(model.product.CategoryId);
            return View(model);
            //var product = await _context.products
            //    .Include(p => p.category)
            //    .FirstOrDefaultAsync(m => m.IdProduct == id);

            //var catarory = await _context.categories
            //    .Where(c => c.IdCategory == product.IdCategory)
            //    .FirstOrDefaultAsync();

            //List<Feature> features = await _context.features
            //    .Where(f => f.IdProduct == product.IdProduct)
            //    .ToListAsync();

            //ProductViewModel model = new ProductViewModel();
            //model.IdProduct = product.IdProduct;
            //model.NameProduct = product.NameProduct;
            //model.Price = product.Price;
            //model.Description = product.Description;
            //model.DescriptionSecond = product.DescriptionSecond;
            //model.Stock = product.Stock;
            //model.MaxStock = product.MaxStock;
            //model.CategoryName = catarory.NameCategory;
            //model.IdCategory = product.IdCategory;
            //model.ImageName = product.ImageName;
            //model.listFeature = features;

            //if (product == null)
            //{
            //    return View("NotFound");
            //}

            //return View(model);
        }

        // POST: admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            // 1. delete image
            // 2. delete feature
            // 3. delete product

            // 1
            _productService.Remove((int)id);
            return RedirectToAction("Index");
            //var product = await _context.products.FindAsync(id);
            //if (DeleteFile(product.ImageName))
            //{
            //    // successfully delete image
            //}
            //else
            //{
            //    // Faild to delete image
            //}

            ////2
            //List<Feature> features = await _context.features.Where(f => f.IdProduct == product.IdProduct).ToListAsync();
            //foreach (var feature in features)
            //{
            //    _context.features.Remove(feature);
            //}

            //// 3
            //_context.products.Remove(product);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.products.Any(e => e.IdProduct == id);
        //}
        #endregion


    }


}

