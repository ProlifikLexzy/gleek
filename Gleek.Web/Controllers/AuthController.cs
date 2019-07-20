using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Gleek.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gleek.Web.Controllers
{

    public class AuthController : Controller
    {
        private readonly string username = "admin";
        private readonly string password = "admin";

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            TempData["failed"] = null;

            if (!ModelState.IsValid)
            {
                TempData["failed"] = "failed";
                model.Password = string.Empty;
                return View(model);
            }

            if (!username.Equals(model.Username, StringComparison.InvariantCultureIgnoreCase) ||
             !password.Equals(model.Password))
            {
                TempData["failed"] = "failed";
                ModelState.AddModelError("Error", "Username or password is invalid");
                return View(model);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim("fullname", model.Username),
                new Claim(ClaimTypes.Role, model.Username),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Initialize claims principal for the claims identity
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            principal, new AuthenticationProperties { IsPersistent = true });

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }
}
