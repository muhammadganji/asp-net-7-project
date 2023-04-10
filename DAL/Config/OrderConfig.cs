using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var enumToString = new ValueConverter<StatusOrder, string>(p => p.ToString()
            , p => (StatusOrder)Enum.Parse(typeof(StatusOrder), p));

            builder.Property(p => p.StatusOrder)
                .HasConversion(enumToString);
        }
    }
}
