using Entities;

namespace Ui.Models
{
    public class SearchViewModel
    {
        // لیست محصولات
        public List<Product> Products { get; set; }
        // منوی گروه ها
        public List<Category> Categories { get; set; }
    }
}
