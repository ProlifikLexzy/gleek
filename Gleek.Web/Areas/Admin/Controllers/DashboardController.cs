using System;
using System.Linq;
using System.Security.Claims;
using Gleek.Core.Models;
using Gleek.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gleek.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController: Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult ListProducts()
        {
            return View();
        }

      
    }
}
