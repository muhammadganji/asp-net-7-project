using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ViewersStatistics
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfVisits { get; set; } = 0;
        [Display(Name = "شناسه کالا")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? product { get; set; }
    }
}
