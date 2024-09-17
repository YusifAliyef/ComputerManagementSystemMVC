using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computer_Shop.Configurations
{
    public class ComputersConfig : IEntityTypeConfiguration<Computers>
    {
        public void Configure(EntityTypeBuilder<Computers> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x => x.Brand)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x=>x.Price)
                .IsRequired();
            builder.Property(x=>x.InStock)
                .IsRequired();
            builder.Property(x => x.Storagetype)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x => x.Processor)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.HasOne(x => x.Sizes)
                .WithOne(x => x.Computers)
                .HasForeignKey<Computers>(x => x.SizeId);
            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Computers)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
