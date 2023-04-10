using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class ProductOrderPaidConfig : IEntityTypeConfiguration<ProductOrderPaid>
    {
        public void Configure(EntityTypeBuilder<ProductOrderPaid> builder)
        {
            
        }
    }
}
