using Entities;

namespace Ui.Models
{
    public class ProductViewModel
    {

        /// <summary>
        /// محصول
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// لیست گروه بندی
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// لیست ویژگی ها
        /// </summary>
        public List<Feature> Features { get; set; }

        /// <summary>
        /// محصولات مشابه
        /// </summary>
        public List<Product> SameProducts { get; set; }

        /// <summary>
        /// لیست نظرات
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// لیست تصاویر
        /// </summary>
        public List<Archive> Archives { get; set; }
    }
}
