using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Ui.Areas.admin.Models;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        public AccountController(IUserRoleService userRoleService, IUserService userService, IRoleService roleService)
        {
            _userRoleService = userRoleService;
            _roleService = roleService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserRoleViewModel> model = new List<UserRoleViewModel>();
            List<IdentityUserRole<string>> userRoles = _userRoleService.GetAll().ToList();
            List<AppUser> users = _userService.GetAll().ToList();
            List<AppRole> roles = _roleService.GetAll().ToList();
            model = (from u in users
                     join ur in userRoles on u.Id equals ur.UserId
                     join r in roles on ur.RoleId equals r.Id
                     select new UserRoleViewModel { Id = u.Id, FullName = u.FirstName + " " + u.LastName, PhoneNumber = u.PhoneNumber, UserName = u.UserName, RoleName = r.Name }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            _userService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
