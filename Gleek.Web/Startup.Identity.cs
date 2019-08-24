using Gleek.Core.Context;
using Gleek.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Web
{
    public partial class Startup
    {
        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<GleekUser, GleekRole>().AddEntityFrameworkStores<GleekDbContext>();
        }
    }
}
