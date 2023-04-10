using Entities;

namespace Ui.Models
{
    public class ProductCartViewModel
    {
        /// <summary>
        /// لیست گروه بندی
        /// </summary>
        public List<Category> Categories = new List<Category>();

        /// <summary>
        /// سبد محصولات
        /// </summary>
        public List<Product> Products = new List<Product>();
    }
}
