using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام گروه")]
        public string? Name { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "نام فایل")]
        public string? FileName { get; set; }

        [Display(Name ="تعداد محصولات")]
        [NotMapped]
        public int ProductCount { get; set; }

        [NotMapped]
        [Display(Name = "تصویر محصول")]
        public IFormFile? ImageFile { get; set; }
    }
}
