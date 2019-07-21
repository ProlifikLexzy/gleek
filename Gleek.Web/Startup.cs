using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gleek.Core.DbAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gleek.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication().AddCookie(options => 
            {
                options.LoginPath ="/Auth/Login";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
                                .RequireAuthenticatedUser()
                                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "MyArea",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public void ConfigureIdentity(ServiceCollection services)
        {
            // https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/
            // Nuget Prequisite
            // =================
            //1. Microsoft.Aspnetcore.Identity
            //2. Microsoft.Aspnetcore.Identity.EntityFrameworkCore
            services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<GleekDbContext>();
        }

        private void ConfigureDbContext(ServiceCollection services)
        {
            services.AddDbContext<GleekDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
