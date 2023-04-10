using Entities;

namespace Ui.Areas.admin.Models
{
    public class ProductOrderPaidViewModel
    {
        public OrderPaid orderPaid { get; set; }
        public List<ProductOrderPaid> productOrderPaids { get; set; }
        /// <summary>
        /// برای نماش لیبل
        /// </summary>
        public ProductOrderPaid productOrderPaid { get; set; }


        public ProductOrderPaidViewModel()
        {
            orderPaid = new OrderPaid();
            productOrderPaid = new ProductOrderPaid();
            productOrderPaids = new List<ProductOrderPaid>();
        }
    }
}
