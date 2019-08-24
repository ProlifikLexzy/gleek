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
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(IRepository<Staff> staffRepository, UserManager<IdentityUser> userManager)
        {
            this.staffRepository = staffRepository;
            this.userManager = userManager;
           
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid && await ValidateCredential(model.Username, model.Password))
            {
                var claimsId = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var claim = new Claim("FullName", model.Username);
                var claimLocation = new Claim("Location", "Abuja");
                claimsId.AddClaim(claim);
                claimsId.AddClaim(claimLocation);

                var principal = new ClaimsPrincipal(claimsId);
                await this.HttpContext.SignInAsync(principal);

                return RedirectToAction("index", "dashboard", new { area = "Admin" });
            }

            return View(model);
        }

        public async Task<bool> ValidateCredential(string username, string password)
        {
            return await userManager.CheckPasswordAsync(new IdentityUser()
            {
                UserName = username
            }, password);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
    }
}
