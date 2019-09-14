using Gleek.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Linq;
using Gleek.Core.Repository;
using Gleek.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Gleek.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IRepository<Staff> staffRepository;
        private readonly UserManager<GleekUser> userManager;

        public AuthController(IRepository<Staff> staffRepository, UserManager<GleekUser> userManager)
        {
            this.staffRepository = staffRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await ValidateCredential(model.Username, model.Password);
            if (this.ModelState.IsValid && user != null)
            {
                var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var claimId = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
                var claim = new Claim("FullName", model.Username);
                var claimLocation = new Claim("Location", "Abuja");
                claimsIdentity.AddClaims(new[] { claimId, claim, claimLocation });

                var principal = new ClaimsPrincipal(claimsIdentity);
                await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("index", "dashboard", new { area = "Admin" });
            }

            return View(model);
        }

        public async Task<GleekUser> ValidateCredential(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
                return null;

            return (await userManager.CheckPasswordAsync(user, password)) ? user : null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
    }
}
