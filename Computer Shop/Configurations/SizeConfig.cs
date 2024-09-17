using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computer_Shop.Configurations
{
    public class SizeConfig : IEntityTypeConfiguration<Sizes>
    {
        public void Configure(EntityTypeBuilder<Sizes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ram)
                .IsRequired();
            builder.Property(x => x.Storage)
                .IsRequired();
            builder.Property(x => x.ScreenSize)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
        }
    }
}
