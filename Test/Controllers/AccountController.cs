using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test.Models.ModelsDB.Entities;
using Test.Models.ModelsDB.ServicesImpl;

namespace Test.Controllers
{
    public class AccountController : Controller
    {

        private AccountService _accountService;

        public AccountController(AccountService repoAccount)
        {
            _accountService = repoAccount;
        }
        public IActionResult Index()
        {
            return View();
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var response = await _accountService.Login(model);
            if (response.StatusCode == Models.ModelsDB.Enum.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        //[HttpGet]
        //public IActionResult Register() => View();

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model) 
        //{ 

        //}
    }
}
