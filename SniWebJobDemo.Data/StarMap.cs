using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SniWebJobDemo.Data
{
    internal class StarMap : IEntityTypeConfiguration<Star>
    {
        public void Configure(EntityTypeBuilder<Star> builder)
        {
            builder.ToTable("Stars");
        }
    }
}
