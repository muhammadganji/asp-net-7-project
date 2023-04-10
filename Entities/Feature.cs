using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "مقدار")]
        public string? Value { get; set; }

        [Display(Name = "شناسه کالا")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? product { get; set; }
    }
}
