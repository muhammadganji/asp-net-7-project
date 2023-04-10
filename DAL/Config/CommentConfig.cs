using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace DAL.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.IsChecked).HasDefaultValue(false);
			// 2023/03/10 11:31
			builder.Property(c => c.TimeStampGenerated).HasComputedColumnSql("GetDate()");


            // First Implement for seed data
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    ProductId = 1,
                    TextComment = "نظر فنی در مورد محصول",
                    ReplyComment = "به زودی به صورت فنی تر مورد بررسی قرار خواهد گرفت. با تشکر شما",
                    FullName = "کاربر اپیلاسیوم",
                    TimeStampIR = "1401/12/10 10:10",
                    IsChecked = true,
                    IsDeleted = false,
                    UserId = "2f4ca569-99bd-4405-8c5d-792424e91a4f",
                }
                );
        }

    }
}
