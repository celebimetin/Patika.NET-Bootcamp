using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.ProductId).IsRequired(true);
            builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired(true).HasPrecision(18, 2).HasDefaultValue(0);
        }
    }
}