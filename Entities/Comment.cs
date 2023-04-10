using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "متن نظر")]
        public string? TextComment { get; set; }
        [Display(Name = "پاسخ نظر")]
        public string? ReplyComment { get; set; }
        [Display(Name = "نام نظر دهنده")]
        public string? FullName { get; set; }
        [Display(Name = "زمان به وقت ایران")]
        public string? TimeStampIR { get; set; }
        [Display(Name = "زمان ثبت نظر")]
        public DateTime TimeStampGenerated { get; set; }
        [Display(Name = "تاییدیه")]
        public bool? IsChecked { get; set; }
        [Display(Name = "حذف شده")]
        public bool? IsDeleted { get; set; }

        [Display(Name = "شناسه محصول")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? product { get; set; }

        [Display(Name = "شناسه کاربر")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser? user { get; set; }
    }
}
