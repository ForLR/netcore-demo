using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mvcCookieAuthSample.Controllers
{
    
    public class AccountController : Controller
    {
        
        public IActionResult MakeLogin()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"lurui"),
                new Claim(ClaimTypes.Role,"admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            //var user = new ClaimsPrincipal(
            //new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name,"lurui"),
            //},
            //CookieAuthenticationDefaults.AuthenticationScheme));
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            //{
            //    IsPersistent = true,
            //    ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(7)) // 有效时间
            //});


            return Ok();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}