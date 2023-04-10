using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Display(Name = "محتوا")]
        public string? Description { get; set; }
        [Display(Name = "تاریخ نگارش")]
        public string? DateTimeCreated { get; set; }
        [Display(Name = "شناسه کاربر")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser? user { get; set; }
    }
}
