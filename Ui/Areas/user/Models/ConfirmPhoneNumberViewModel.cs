using System.ComponentModel.DataAnnotations;

namespace Ui.Areas.user.Models
{
    public class ConfirmPhoneNumberViewModel
    {
        [Display(Name = "تاییدیه موبایل")]
        public bool PhoneNumberConfirmed { get; set; }
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }
        [Display(Name = "کد اعتبار سنجی")]
        public string CodeOtp { get; set; }
    }
}
