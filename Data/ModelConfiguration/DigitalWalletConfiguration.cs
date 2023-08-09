using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class DigitalWalletConfiguration : IEntityTypeConfiguration<DigitalWallet>
    {
        public void Configure(EntityTypeBuilder<DigitalWallet> builder)
        {
            builder.ToTable(name: "DigitalWallet", schema: "dbo");
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.Balance).IsRequired(true).HasPrecision(18, 2).HasDefaultValue(0);

            builder.HasIndex(x => x.UserId).IsUnique();
        }
    }
}