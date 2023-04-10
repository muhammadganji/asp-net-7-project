using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductOrderPaid
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "قیمت")]
        public ulong Price { get; set; } = 0;
        [Display(Name = "تعداد")]
        public uint Quantity { get; set; }
        [Display(Name = "شناسه محصول")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? product { get; set; }
        [Display(Name = "شناسه فاکتور")]
        public int OrderPaidId { get; set; }
        [ForeignKey("OrderPaidId")]
        public virtual OrderPaid? orderPaid { get; set; }
    }
}
