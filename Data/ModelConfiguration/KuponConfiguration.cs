using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class KuponConfiguration : IEntityTypeConfiguration<Kupon>
    {
        public void Configure(EntityTypeBuilder<Kupon> builder)
        {
            builder.ToTable(name: "Kupon", schema: "dbo");
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Rate).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.Code).IsRequired(true).HasMaxLength(10);
            builder.Property(x => x.Duration).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);

            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}