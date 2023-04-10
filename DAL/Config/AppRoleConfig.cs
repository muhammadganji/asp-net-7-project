using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // First Implement for seed data
            builder.HasData(
                new AppRole
                {
                    Id = "b76cdd25-c852-4afa-995d-5b73bc7d6109",
                    ConcurrencyStamp = "e63943b6-5eeb-4d32-8320-22b40200527f",
                    Description = "sysadmin",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole
                {
                    Id = "5e8e57de-2b3c-48ab-9d4f-f33facdb8eed",
                    ConcurrencyStamp = "d404344e-4855-4e72-9743-704f7c618e5e",
                    Description = "regular user",
                    Name = "user",
                    NormalizedName = "USER"
                });
        }
    }
}
