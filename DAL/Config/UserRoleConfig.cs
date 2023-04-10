using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Config
{
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // First Implement for seed data
            builder.HasData(
                new IdentityUserRole<string> // admin
                {
                    RoleId = "b76cdd25-c852-4afa-995d-5b73bc7d6109",
                    UserId = "16dbb2ed-0a86-499a-9296-2d0efa1def54"
                },
                new IdentityUserRole<string> // user
                {
                    UserId = "2f4ca569-99bd-4405-8c5d-792424e91a4f",
                    RoleId = "5e8e57de-2b3c-48ab-9d4f-f33facdb8eed"
                });

        }

    }
}
