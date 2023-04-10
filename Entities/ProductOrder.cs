using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "تعداد")]
        public uint Quantity { get; set; }
        [Display(Name = "محصول")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? product { get; set; }
        [Display(Name = "سفارش")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? order { get; set; }
    }
}
