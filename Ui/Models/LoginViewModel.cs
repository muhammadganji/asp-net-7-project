using Entities;
using System.ComponentModel.DataAnnotations;

namespace Ui.Models
{
    public class LoginViewModel
    {
        [Display(Name = "همراه")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string UserName { get; set; }

        [Display(Name = "رمز")]
        [Required(ErrorMessage = "لطفا رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
