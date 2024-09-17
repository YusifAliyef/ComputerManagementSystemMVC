using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computer_Shop.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
           builder.HasKey(x=>x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(x=>x.PhoneNumber)
                .IsRequired();
            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            
        }
    }
}
