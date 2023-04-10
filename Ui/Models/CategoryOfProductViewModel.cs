using Entities;

namespace Ui.Models
{
    public class CategoryOfProductViewModel
    {
        // برای محصولات یک گروه خاص
        public List<Product> Products { get; set; }
        // برای منو
        public List<Category> Categories { get; set; }

        // نام گروه
        public string CategoryName { get; set; }
        // تصویر گروه
        public string ImageName { get; set; }
    }
}
