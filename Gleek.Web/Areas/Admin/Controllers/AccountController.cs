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
    public class AccountController: BaseController
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public ViewResult CreateAccount(Account account)
        {
           
            account.CreatedBy_Id = this.UserId;
            accountService.CreateAccount(account);

            return View(account);
        }
    }
}
