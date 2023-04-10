using Entities;

namespace Ui.Models
{
    public class HomeViewModel
    {
        /// <summary>
        /// use for show last product added
        /// </summary>
        public List<Product> LastProducts = new List<Product>();
        /// <summary>
        /// use for create menu
        /// </summary>
        public List<Category> Categorys = new List<Category>();

        /// <summary>
        /// محصولاتی که در اسلایدر نمایش داده خواهد شد
        /// </summary>
        public List<Product>? SliderProducts { get; set; } = new List<Product>();
    }
}
