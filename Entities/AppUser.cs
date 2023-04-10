using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AppUser: IdentityUser
    {
        [Display(Name = "نام")]
        public string? FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; }
        [Display(Name = "کدپستی")]
        public string? Zipcode { get; set; }
    }
}
