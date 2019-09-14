using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public Guid UserId
        {
            get
            {
                var claimIdentity = this.User.Identity as ClaimsIdentity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
                return Guid.Parse(claim.Value);
            }
        }

        public string FullName
        {
            get
            {
                var claimIdentity = this.User.Identity as ClaimsIdentity;
                var claim = claimIdentity.FindFirst("FullName");
                return claim.Value;
            }
        }

    }
}
