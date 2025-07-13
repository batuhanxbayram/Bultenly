using Bultenly.Domain.Entities;
using Bultenly.Sql.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bultenly.Sql.Context
{
    public class AppContext : IdentityDbContext<User, Role, Guid>
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

       
        public DbSet<ContentSource> ContentSources { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContentSourceConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
      
        }
    }
}
