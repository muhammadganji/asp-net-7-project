using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AppRole: IdentityRole
    {
        [Display(Name = "توضیح نقش")]
        public string? Description { get; set; }
    }
}
