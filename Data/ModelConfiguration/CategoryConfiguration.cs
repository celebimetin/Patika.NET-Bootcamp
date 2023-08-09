using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(name: "Categories", schema: "dbo");
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Picture).IsRequired(true).HasMaxLength(100);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}