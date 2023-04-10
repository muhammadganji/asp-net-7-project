using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        [Display(Name = "شماره سفارش")]
        public int Id { get; set; }
        [Display(Name = "تاریخ سفارش")]
        public string? DateOrder { get; set; }
        [Display(Name = "وضعیت سفارش")]
        public StatusOrder StatusOrder { get; set; } = StatusOrder.InCart;
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        [Display(Name = "شناسه کاربر")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser? user { get; set; }
    }
}
