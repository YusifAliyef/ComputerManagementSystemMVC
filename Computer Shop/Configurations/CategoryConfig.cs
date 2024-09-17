using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computer_Shop.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            
            
        }
    }
}
