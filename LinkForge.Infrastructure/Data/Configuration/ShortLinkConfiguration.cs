using LinkForge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkForge.Infrastructure.Data.Configuration;

public class ShortLinkConfiguration : IEntityTypeConfiguration<ShortLink>
{
    public void Configure(EntityTypeBuilder<ShortLink> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ShortCode)
            .IsUnique();

        builder.Property(x => x.ShortCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.OriginalUrl)
            .IsRequired();

        builder.Property(x => x.ClickCount)
            .HasDefaultValue(0);

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}