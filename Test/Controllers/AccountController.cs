using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DataBase.Entities;
using Core.Service;
using System.Net;

namespace Test.Controllers
{
    public class AccountController : Controller
    {

        private AccountService _accountService;

        public AccountController(AccountService repoAccount)
        {
            _accountService = repoAccount;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            var response = await _accountService.Login(model);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
