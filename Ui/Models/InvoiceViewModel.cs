using Entities;
using Microsoft.Graph;

namespace Ui.Models
{
    public class InvoiceViewModel
    {
        /// <summary>
        /// مشخصات فروشگاه
        /// </summary>
        public AppUser CompanyInfo { get; set; }
        /// <summary>
        /// مشخصات مشتری
        /// </summary>
        public AppUser UserInfo { get; set; }
        /// <summary>
        /// لیست محصولات به همراه تعداد
        /// </summary>
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public string DateTimeCreateIR { get; set; }
    }

}
