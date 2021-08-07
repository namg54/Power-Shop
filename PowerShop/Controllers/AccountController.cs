using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using PowerShop.Data.Repositories;
using PowerShop.Models;
using Microsoft.AspNetCore.Authentication;

namespace PowerShop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _iUserRepository;

        public AccountController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            //if (_iUserRepository.IsExistUserByEmail(registerViewModel.Email.ToLower()))
            //{
            //    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
            //    return View(registerViewModel);
            //}

            Users user = new Users()
            {
                Email = registerViewModel.Email.ToLower(),
                Password = registerViewModel.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now
            };

            _iUserRepository.AddUser(user);

            return View("SuccessRegister", registerViewModel);
        }


        public IActionResult VerifyEmail(string email)
        {
            if (_iUserRepository.IsExistUserByEmail(email.ToLower()))
            {
                return Json("ایمیل وارد شده تکراری است");
            }

            return Json(true);
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _iUserRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString())
                // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");

        }

        #endregion



        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
