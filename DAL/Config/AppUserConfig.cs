using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.PhoneNumber)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));

            //builder.Property(p => p.UserName)
            //    .HasComputedColumnSql("'Hirkan' + CAST(FORMAT (getdate(), 'yyyyddMM') AS varchar) + Cast(FLOOR(rand()*(9999-2500)+2500) AS varchar)");

            builder.Property(p => p.Address)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));

            builder.Property(p => p.FirstName)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));

            builder.Property(p => p.LastName)
                .HasConversion(p => Base64Encode(p), p => Base64Decode(p));


            // First Implement for seed data
            builder.HasData(
                new AppUser
                {
                    // admin
                    Id = "16dbb2ed-0a86-499a-9296-2d0efa1def54",
                    FirstName = "ادمین",
                    LastName = "سیستم",
                    Email = "Email@mail.com",
                    NormalizedEmail = "EMAIL@MAIL.COM",
                    LockoutEnabled = true,
                    UserName = "admin",
                    PhoneNumber = "admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumberConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAENgFrB71A/cyVJ+9bbacZbl/B5m8n7ZUz58PLrwq2t/IuZ6UAfjDMbyfAhQWhvQN9Q==",
                    ConcurrencyStamp = "e81029bb-1f0e-4e7a-af39-3e8addb66122",
                    SecurityStamp = "VBGSDPHC64HP7IFCRGGBYPMDSCCTIY7Y"
                }, new AppUser
                {
                    Id = "2f4ca569-99bd-4405-8c5d-792424e91a4f",
                    FirstName = "محمد",
                    LastName = "گنجی نژاد",
                    UserName = "Hirkan202302038855",
                    PhoneNumber = "09167189048",
                    NormalizedUserName = "HIRKAN202302038855",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEClRby1OuLn9VpY0nSbRS402ma+Kb6fhTyclE3/4WrDqDZSC4kXZsVYwHRhxd0O9lA==",
                    SecurityStamp = "KXRAHZOOK6QNVFDG6PNOWSQYVUDEK6PG",
                    ConcurrencyStamp = "992957d8c-6477-462e-a9fe-e8c3a1aabcc7"
                }
                );

        }

        public static string Base64Encode(string painText)
        {
            var painTextBytes = System.Text.Encoding.UTF8.GetBytes(painText);
            return System.Convert.ToBase64String(painTextBytes);
        }

        public static string Base64Decode(string base64EncodeedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodeedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }



    }
}
