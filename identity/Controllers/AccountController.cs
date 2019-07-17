using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace identity.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<User> _user;
        private RoleManager<Role> _role;

        public AccountController(UserManager<User> user, RoleManager<Role> role)
        {
            this._user = user;
            this._role = role;
        }

        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var user = new User()
            {
                Email= register.Email,
                UserName=register.Email,
                NormalizedUserName=register.Email

            };

            var indentity = await _user.CreateAsync(user, register.Password);
            if (indentity.Succeeded)
            {
                return RedirectToAction("Account","Login");
            }
            return View();
        }
        public IActionResult Login()
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"wyt"),
                new Claim(ClaimTypes.Role,"admin")
            };

            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
            return Ok();

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}