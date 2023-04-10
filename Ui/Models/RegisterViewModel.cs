using Entities;
using System.ComponentModel.DataAnnotations;

namespace Ui.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد نمایید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        public string LastName { get; set; }

        [Display(Name = "همراه")]
        [Required(ErrorMessage = "لطفا همراه را وارد نمایید")]
        [DataType(DataType.PhoneNumber)]
        public string UserName { get; set; }


        [Display(Name = "رمز")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا رمز عبور را وارد نمایید")]
        public string Password { get; set; }

        /// <summary>
        /// کد تاییدیه ثبت نام
        /// </summary>
        [Display(Name = "کد تاییدیه")]
        public string? CodeOTP { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
