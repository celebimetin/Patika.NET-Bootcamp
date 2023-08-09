using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfiguration
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Code).IsRequired(true).HasMaxLength(200);

            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}