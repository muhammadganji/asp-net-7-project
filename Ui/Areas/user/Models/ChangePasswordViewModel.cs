using System.ComponentModel.DataAnnotations;

namespace Ui.Areas.user.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "رمز جدید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [MinLength(8, ErrorMessage = "حداقل 8 حرف ضروری است"), MaxLength(24, ErrorMessage = "حداکثر 24 حرف میتوانید وارد نمایید.")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز جدید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "این فیلد نباید خالی باشد")]
        [MinLength(8, ErrorMessage = "حداقل 8 حرف ضروری است"), MaxLength(24, ErrorMessage = "حداکثر 24 حرف میتوانید وارد نمایید.")]
        [Compare("Password", ErrorMessage = "رمز جدید با تکرار رمز یکسان نیست.")]
        public string ConfirmPassword { get; set; }
    }
}
