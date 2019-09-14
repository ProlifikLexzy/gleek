using Gleek.Core.Models;
using Gleek.Core.Models.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Context
{
    public class GleekDbContext : IdentityDbContext<GleekUser, GleekRole, Guid, GleekUserClaim, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public GleekDbContext(DbContextOptions<GleekDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GleekUserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

