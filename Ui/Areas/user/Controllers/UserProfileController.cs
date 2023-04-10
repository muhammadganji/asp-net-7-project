using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ui.Areas.user.Models;
using Ui.Tools;

namespace Ui.Areas.user.Controllers
{
    [Area("user")]
    [Authorize(Roles = "user")]
    public class UserProfileController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private static string _codeOTP;
        public UserProfileController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserService userService)
        {
            _codeOTP = string.Empty;
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            string usreId = _userManager.GetUserId(User);
            AppUser model = _userService.GetById(usreId);
            return View(model);
        }

        #region Edit
        [HttpGet]
        public IActionResult Edit()
        {
            string usreId = _userManager.GetUserId(User);
            AppUser model = _userService.GetById(usreId);
            return View(model);

            //UserInfoViewModel model = new UserInfoViewModel();
            //var userName = _userManager.GetUserName(User);
            //var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();
            //if (user == null)
            //{
            //    return View("NotFound");
            //}
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            //model.PhoneNumber = user.PhoneNumber;
            //model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            //model.Address = user.Address;
            //model.PostCode = user.PostCode;
            //return View(model);
        }


        [HttpPost]
        public IActionResult Edit(AppUser user)
        {
            _userService.Update(user);
            string userId = _userManager.GetUserId(User);
            AppUser model = _userService.GetById(userId);
            return View("Index", model);

            //UserInfoViewModel model = new UserInfoViewModel();
            //var userName = _userManager.GetUserName(User);
            //var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();
            //if (user == null)
            //{
            //    return View("NotFound");
            //}
            //// update data
            //user.FirstName = FormData.FirstName;
            //user.LastName = FormData.LastName;
            //user.Address = FormData.Address;
            //user.PostCode = FormData.PostCode;
            //_dbcontex.Users.Update(user);
            //_dbcontex.SaveChanges();
            ////------------------- return
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            //model.PhoneNumber = user.PhoneNumber;
            //model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            //model.Address = user.Address;
            //model.PostCode = user.PostCode;
        }
        #endregion

        #region Change-password
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// change password without old password
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel password)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = true;
                return View(password);
            }

            string userId = _userManager.GetUserId(User);
            AppUser user = _userService.GetById(userId);
            if (user != null)
            {
                ViewBag.FullName = user.FirstName + " " + user.LastName;
                // Generate Token
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                // Set new Password
                var result = await _userManager.ResetPasswordAsync(user, token, password.Password);
                if (result.Succeeded)
                {
                    ViewBag.Result = true;
                }
                else
                {
                    ViewBag.Result = false;
                }
                return View();
            }
            return View("NotFound");

            //// get user info
            //var userName = _userManager.GetUserName(User);
            //var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();

            //UserInfoViewModel model = new UserInfoViewModel();
            //if (user == null)
            //{
            //    return View("NotFound");
            //}
            //ViewBag.FullName = user.FirstName + " " + user.LastName;
            //// change password with out old password
            ////Generate Token
            //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            ////Set new Password
            //var result = await _userManager.ResetPasswordAsync(user, token, DataForm.Password);
            //if (result.Succeeded)
            //{
            //    ViewBag.Result = true;
            //}
            //else
            //{
            //    ViewBag.Result = false;
            //}
            //return View();
        }
        #endregion

        #region Confirm-mobile
        [HttpGet]
        public IActionResult ConfirmPhoneNumber()
        {
            ConfirmPhoneNumberViewModel model = new ConfirmPhoneNumberViewModel();
            string userId = _userManager.GetUserId(User);
            AppUser user = _userService.GetById(userId);
            if (user != null)
            {
                model.PhoneNumber = user.PhoneNumber;
                model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                return View(model);
            }
            else
            {
                return View("NotFound");
            }

            // var userName = _userManager.GetUserName(User);
            // var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();
            //if (user == null)
            //{
            //    return View("NotFound");
            //}

            //model.PhoneNumber = user.PhoneNumber;
            //model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;

            //return View(model);

        }

        [HttpPost]
        public IActionResult ConfirmPhoneNumber(ConfirmPhoneNumberViewModel input)
        {

            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //---------------complate it---------------
            //UserInfoViewModel model = new UserInfoViewModel();
            //var userName = _userManager.GetUserName(User);
            //var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();
            string userId = _userManager.GetUserId(User);
            AppUser user = _userService.GetById(userId);
            if (user != null)
            {
                if (input.CodeOtp == _codeOTP)
                {
                    user.PhoneNumberConfirmed = true;
                    _userService.Update(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(input);
                }
            }
            else
            {
                return View("NotFound");
            }

            //_dbcontex.Users.Update(user);
            //_dbcontex.SaveChanges();

            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            //model.PhoneNumber = user.PhoneNumber;
            //model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            //model.Address = user.Address;
            //model.PostCode = user.PostCode;
            //return View("Index", model);
            //return View();
        }

        /// <summary>
        /// درخواست کد احراز هویت
        /// </summary>
        public async Task<IActionResult> PostRegisterOTP(string PhoneNumber)
        {

            MessageSms message = new MessageSms();
            try
            {
                string userId = _userManager.GetUserId(User);
                AppUser user = _userService.GetById(userId);

                // string username = _userManager.GetUserName(User);
                // var user = _dbcontex.Users.Where(u => u.UserName == username).SingleOrDefault();
                _codeOTP = await message.SendOTP(user.PhoneNumber);
                return Json(new { message = "that greate code" });
            }
            catch { return Json(new { error = "Never Give Up" }); }



            //CompanyInfo info = new CompanyInfo();
            //string UserName = info.UserName;
            //string Password = info.Password;
            //int PatternCodeID = info.PatternCodeIDOTP;
            //DateTime SendDateTime = DateTime.Now;

            // خوندن اطلاعات به صورت تنظیماتی
            //XmlDocument doc = new XmlDocument();
            //doc.Load("DataXMLFile.xml");
            //string UserName = doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("UserName")[0].InnerText;
            //string Password = doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("Password")[0].InnerText;
            //int PatternCodeID = Convert.ToInt32(doc.SelectNodes("DocumentElement/Amoot")[0].SelectNodes("PatternCodeIDOTP")[0].InnerText);

            //var userName = _userManager.GetUserName(User);
            //var user = _dbcontex.Users.Where(u => u.UserName == userName).FirstOrDefault();
            //string Mobile = user.PhoneNumber;

            //var rand = new Random();
            //int codeGenerateforOTP = rand.Next(30000, 70001);
            //string[] PatternValues = new string[] { codeGenerateforOTP.ToString() };


            //AmootSMSWebService2SoapClient client = new AmootSMSWebService2SoapClient
            //    (new AmootSMSWebService2SoapClient.EndpointConfiguration());

            //try
            //{

            //    SendResult result = await client.SendWithPatternAsync(UserName, Password,
            //        Mobile, PatternCodeID, PatternValues);

            //    if (result.Status == Status.Success)
            //    {
            //        //خروجی
            //        _CodeOTP = codeGenerateforOTP.ToString();
            //        return Json(new { message = "that greate code" });
            //    }
            //    else { return Json(new { error = "Never Give Up" }); }

            //}
            //catch (Exception ex)
            //{
            //    string rMessage = ex.Message;
            //    return Json(new { error = "Never Give Up" });
            //}

        }
        #endregion

    }
}
