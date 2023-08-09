using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Products", schema: "dbo");
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.UnitPrice).IsRequired(true).HasPrecision(18, 2).HasDefaultValue(0);
            builder.Property(x => x.UnitsInStock).IsRequired(true).HasMaxLength(100).HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.IsStatus).IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}