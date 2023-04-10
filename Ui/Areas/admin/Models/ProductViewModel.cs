using Entities;

namespace Ui.Areas.admin.Models
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Feature> Features { get; set; }
        public List<Archive> Archives { get; set; }

        /// <summary>
        /// صرفا برای نمایش لیبل
        /// </summary>
        public Product product { get; set; }
        /// <summary>
        /// صرفا برای نمایش لیبل
        /// </summary>
        public Category category { get; set; }
        /// <summary>
        /// صرفا برای نمایش لیبل
        /// </summary>
        public Feature feature { get; set; }
        /// <summary>
        /// صرفا برای نمایش لیبل
        /// </summary>
        public Archive archive { get; set; }
        
        public ProductViewModel()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
            Features = new List<Feature>();
            Archives = new List<Archive>();
        }
    }
}
