using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Config
{
    public class ArchiveConfig : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            // 2023/03/13 16:07
            builder.Property(a => a.DateTimeCreated).HasComputedColumnSql("GetDate()");
        }
    }
}
