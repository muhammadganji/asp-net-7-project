using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Config
{
    public class OrderPaidConfig : IEntityTypeConfiguration<OrderPaid>
    {
        public void Configure(EntityTypeBuilder<OrderPaid> builder)
        {
            var enumToString = new ValueConverter<StatusOrder, string>(p => p.ToString()
            , p => (StatusOrder)Enum.Parse(typeof(StatusOrder), p));

            builder.Property(p => p.StatusOrder)
                .HasConversion(enumToString);
        }
    }
}
