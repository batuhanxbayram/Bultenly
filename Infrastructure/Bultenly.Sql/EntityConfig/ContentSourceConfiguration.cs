// Infrastructure\Bultenly.Sql\EntityConfig\ContentSourceConfiguration.cs
using Bultenly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bultenly.Sql.EntityConfig
{
    public class ContentSourceConfiguration : IEntityTypeConfiguration<ContentSource>
    {
        public void Configure(EntityTypeBuilder<ContentSource> builder)
        {
            builder.HasKey(cs => cs.Id);
            builder.Property(cs => cs.Name).IsRequired();
            builder.Property(cs => cs.Url).IsRequired();
            builder.Property(cs => cs.ContentType).IsRequired();
            builder.Property(cs => cs.IsActive).IsRequired();

            builder.HasMany(cs => cs.Articles)
                .WithOne(a => a.ContentSource)
                .HasForeignKey(a => a.ContentSourceId);
        }
    }
}