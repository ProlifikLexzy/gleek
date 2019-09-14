using Gleek.Core.Context;
using Gleek.Core.Models;
using Gleek.Core.Repository;
using Gleek.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gleek.Web
{
    public partial class Startup
    {
        public void RegisterService(IServiceCollection services)
        {
            services.AddTransient<AccountService, AccountService>();
            services.AddTransient<CustomerService, CustomerService>();
            services.AddTransient<IRepository<Staff>, EntityRepository<Staff>>();
            //services.AddTransient(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddScoped<GleekDbContext>();
        }
    }
}
