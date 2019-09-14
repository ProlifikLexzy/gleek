using Gleek.Core.Models;
using Gleek.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Web.Areas.Admin.Controllers
{
    public class CustomerController: BaseController
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            customer.CreatedBy_Id = this.UserId;
            customerService.CreateCustomer(customer);

            return View(customer);
        }
    }
}
