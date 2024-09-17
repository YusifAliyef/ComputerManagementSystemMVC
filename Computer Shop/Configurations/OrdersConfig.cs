using Computer_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computer_Shop.Configurations
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderDate)
                .IsRequired();
            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.Property(x => x.TotalPrice)
                .IsRequired();
            builder.HasOne(x => x.Customers)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);


        }
    }
}
