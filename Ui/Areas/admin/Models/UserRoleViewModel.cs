using System.ComponentModel.DataAnnotations;

namespace Ui.Areas.admin.Models
{
    public class UserRoleViewModel
    {
        [Display(Name = "شناسه کاربری")]
        public string Id { get; set; }
        [Display(Name = "نام کامل")]
        public string FullName { get; set; }
        [Display(Name = "همراه")]
        public string PhoneNumber { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "نقش")]
        public string RoleName { get; set; }
    }
}
