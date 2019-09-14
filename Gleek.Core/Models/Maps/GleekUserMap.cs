using Gleek.Core.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Models.Maps
{
    public class GleekUserMap : IEntityTypeConfiguration<GleekUser>
    {
        public PasswordHasher<GleekUser> Hasher { get; set; } = new PasswordHasher<GleekUser>();
        public void Configure(EntityTypeBuilder<GleekUser> builder)
        {
            SetupUser(builder);
        }

        private void SetupUser(EntityTypeBuilder<GleekUser> builder)
        {
            var staff = new GleekUser
            {
                FirstName = "Gleek",
                LastName = "United",
                Id = Guid.Parse("b3ca9941-c556-4189-8c4a-538959f24e43"),
                Email = "superadmin@gleek.com",
                EmailConfirmed = true,
                NormalizedEmail = "superadmin@gleek.com".ToUpper(),
                PhoneNumber = "080062066851",
                UserName = "superadmin@gleek.com",
                NormalizedUserName = "superadmin@gleek.com".ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "b3ca9941-c556-4189-8c4a-538959f24e43",
                UserType = UserTypes.STAFF,
            };

            var customer = new GleekUser
            {
                FirstName = "Gleek",
                LastName = "United",
                PassportNo = "X12345554",
                Id = Guid.Parse("13fd605b-6828-46d0-ac6f-5c69fcd9da64"),
                Email = "customer@yahoo.com",
                EmailConfirmed = true,
                NormalizedEmail = "customer@yahoo.com".ToUpper(),
                PhoneNumber = "080062066852",
                UserName = "customer@yahoo.com",
                NormalizedUserName = "customer@yahoo.com".ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "13fd605b-6828-46d0-ac6f-5c69fcd9da64",
                UserType = UserTypes.CUSTOMER,
            };

            builder.HasData(new[] { staff, customer });
        }
    }
}
