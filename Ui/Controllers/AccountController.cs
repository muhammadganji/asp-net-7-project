using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.SecurityNamespace;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Ui.Models;
using Ui.Tools;

namespace Ui.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _user;
        private readonly IRoleService _role;
        private readonly ICategoryService _categories;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IUserService userService,
            IRoleService roleService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            ICategoryService category)
        {
            _user = userService;
            _role = roleService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _categories = category;
        }

        #region Login

        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {

            //string username = _user.GetEncode("admin");
            if (_signInManager.IsSignedIn(User))
            {
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
                LoginViewModel model = new LoginViewModel();
                model.Categories = _categories.GetAll().ToList();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = null)
        {
            model.Categories = _categories.GetAll().ToList();
            if (ModelState.IsValid)
            {
                string realUsername = _user.GetUserNameByPhoneNumber(model.UserName);
                if (realUsername != string.Empty)
                {
                    var result = await _signInManager.PasswordSignInAsync(realUsername, model.Password, model.RememberMe, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        // correct username and password
                        var UserRole = User.FindFirstValue(ClaimTypes.Role);
                        return RedirectToLocal(UserRole, ReturnUrl);
                    }
                    if (result.IsLockedOut)
                    {
                        // account has lockout
                        #region commented
                        //var forgotPassLink = Url.Action(nameof(ForgotPassword), "Account", new { }, Request.Scheme);
                        //var content = string.Format("Your account is locked out, to reset your password, please click this link: {0}", forgotPassLink);
                        //var message = new Message(new string[] { userModel.Email }, "Locked out account information", content, null);
                        //await _emailSender.SendEmailAsync(message);
                        #endregion
                        ViewBag.ForgotPassword = true;
                        ModelState.AddModelError("", "اکانت شما به دلیل وارد کردن رمز اشتباه بیش از حد مسدود شده. اگر رمز خود را فراموش کرده اید از بخش فراموشی رمز آن را بازیابی نمایید. با احترام");
                        return View(model);
                    }
                    // wrong password
                    ModelState.AddModelError("", "رمز عبور صحیح نیست.");
                    ViewBag.ForgotPassword = true;
                    return View(model);
                }
                else
                {
                    // username not found
                    ModelState.AddModelError("", "نام کاربری یافت نشد");
                    return View(model);
                }
            }
            // error equire
            ModelState.AddModelError("", " در وارد کردن مشخصات خطا رخ داد");
            return View(model);
        }

        #endregion

        #region Logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // clear cookeies
            if (Request.Cookies["_product"] != null)
            {
                Response.Cookies.Delete("_product");
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Categories = _categories.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 1. Check username
                // 2. Register user + role
                // 3. Login

                bool result = _user.CheckPhoneNumber(model.UserName);
                if (!result)
                {
                    AppUser user = new AppUser
                    {
                        UserName = GenerateContent.UserName(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.UserName,
                    };
                    var result2 = await _userManager.CreateAsync(user, model.Password);
                    if (result2.Succeeded)
                    {
                        AppRole roleUser = _role.GetRole("user");
                        AppRole role = await _roleManager.FindByIdAsync(roleUser.Id);
                        if (role != null)
                        {
                            var result3 = await _userManager.AddToRoleAsync(user, role.Name);
                            if (result3.Succeeded)
                            {
                                await _signInManager.SignInAsync(user, false);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }

            }
            model.Categories = _categories.GetAll().ToList();
            return View(model);
        }

        #endregion

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        #region panel
        public IActionResult GoToPanel()
        {
            // Get role with Database
            var UserRole = User.FindFirstValue(ClaimTypes.Role);
            return RedirectToLocal(UserRole);
        }
        #endregion

        #region site rules

        [HttpGet]
        public IActionResult SiteRules()
        {
            List<Category> model = new List<Category>();
            model = _categories.GetAll().ToList();
            return View(model);
        }
        #endregion

        #region access denied

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

        #region tool
        private IActionResult RedirectToLocal(string userRole, string ReturnUrl = null)
        {

            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            else if (userRole == "admin")
            {
                return Redirect("/admin/AdminProfile/Index");
            }
            else if (userRole == "user")
            {
                return Redirect("/user/UserProfile/Index");
            }
            else
            {
                // اگر مسیر اشتباه بود یا کاربر فقط میخواهد لاگین نماید
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

    }
}
