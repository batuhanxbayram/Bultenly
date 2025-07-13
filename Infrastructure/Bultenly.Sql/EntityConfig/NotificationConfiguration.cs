// Infrastructure\Bultenly.Sql\EntityConfig\NotificationConfiguration.cs
using Bultenly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bultenly.Sql.EntityConfig
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Content).IsRequired();
            builder.Property(n => n.MessageType).IsRequired();

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            builder.HasOne(n => n.Article)
                .WithMany()
                .HasForeignKey(n => n.ArticleId)
                .IsRequired(false);
        }
    }
}