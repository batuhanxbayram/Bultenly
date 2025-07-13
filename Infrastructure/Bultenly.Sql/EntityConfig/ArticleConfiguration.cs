// Infrastructure\Bultenly.Sql\EntityConfig\ArticleConfiguration.cs
using Bultenly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bultenly.Sql.EntityConfig
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Url).IsRequired();
            builder.Property(a => a.PublishedDate).IsRequired();
            builder.Property(a => a.ScannedDate).IsRequired();

            builder.HasOne(a => a.ContentSource)
                .WithMany(cs => cs.Articles)
                .HasForeignKey(a => a.ContentSourceId);
        }
    }
}