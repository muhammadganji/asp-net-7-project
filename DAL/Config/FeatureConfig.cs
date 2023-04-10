using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData(
                new Feature
                {
                    Id = 1,
                    ProductId = 1,
                    Title = "اپیلاسیوم",
                    Value = "محتوای اپیلاسیوم"
                }, new Feature
                {
                    Id = 2,
                    ProductId = 1,
                    Title = "اپیلاسیوم",
                    Value = "محتوای غیز تکراری اپیلاسیوم"
                });
        }
    }
}
