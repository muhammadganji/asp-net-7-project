using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            // First Implement for seed data
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    Stock = 2,
                    CategoryId = 1
                }, new Product
                {
                    Id = 2,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    Stock=3,
                    CategoryId = 1
                }, new Product
                {
                    Id = 3,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    Stock=2,
                    CategoryId = 2
                }, new Product
                {
                    Id = 4,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    Stock=3,
                    CategoryId = 2
                }, new Product
                {
                    Id = 5,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    Stock=1,
                    CategoryId = 1
                }, new Product
                {
                    Id = 6,
                    Name = "محصول اپیلاسیوم",
                    Description = "توضیح اپیلاسیوم",
                    ImageName = "Product-Guid-image.gif",
                    Price = 15000,
                    CategoryId = 2
                });
        }
    }
}
