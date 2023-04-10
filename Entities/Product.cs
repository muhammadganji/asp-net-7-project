using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کالا")]
        public string? Name { get; set; }

        [Display(Name = "توضیح یک خطی")]
        public string? Description { get; set; }
        [Display(Name = "توضیح تخصصی محصول")]
        public string? DescriptionSecond { get; set; } = "";

        [Display(Name = "تصویر")]
        public string? ImageName { get; set; }
        [Display(Name = "تصویر")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "قیمت")]
        public ulong Price { get; set; } = 0;

        [Display(Name = "موجودی")]
        public uint Stock { get; set; } = 0; // maxValue 65535
        [Display(Name = "سقف خرید")]
        public uint MaxStock { get; set; } = 1;
        /// <summary>
        /// صرفا برای ثبت فاکتور در سبد خرید
        /// </summary>
        [NotMapped]
        public uint? Quantity { get; set; } = 1; // it does not save in database: just use in invoiceCart

        [Display(Name = "نام گروه")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? category { get; set; }
    }
}
