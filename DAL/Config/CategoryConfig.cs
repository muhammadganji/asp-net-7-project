using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // First Implement for seed data
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "گروه اپیلاسیوم",
                    FileName = "Category-Guid-image.gif",
                    Description = "توضیح اپیلاسیوم"
                }, new Category
                {
                    Id = 2,
                    Name = "گروه اپیلاسیوم",
                    FileName = "Category-Guid-image.gif",
                    Description = "توضیح اپیلاسیوم"
                }, new Category
                {
                    Id = 3,
                    Name = "گروه اپیلاسیوم",
                    FileName = "Category-Guid-image.gif",
                    Description = "توضیح اپیلاسیوم"
                });
        }
    }
}
