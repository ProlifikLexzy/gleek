using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gleek.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Gleek.Core.Models;
using Gleek.Core.ViewModels;
using Gleek.Core.Services;
using System.Linq;

namespace Gleek.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerService customerService;

        public HomeController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerViewModel model)
        {
           var result = customerService.CreateCustomer((Customer)model);

            if (result == false)
            {
                var errorMessage = customerService.Errors.FirstOrDefault().Value;
                return View(errorMessage);
            }

            return View();
        }

        public IActionResult Index()
        {

            var customer = new Customer();
            CustomerViewModel customerVM = customer;
            return View();
        }

        public IActionResult GoToAdmin()
        {

            var customer = new Customer();
            CustomerViewModel customerVM = customer;
            return RedirectToAction("Index", "Dashboard", new { area="Admin"});
        }

        public IActionResult Privacy()
        {
            var customer = new Customer();
            CustomerViewModel customerVM = customer;

            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
