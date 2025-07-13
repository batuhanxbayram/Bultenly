using Bultenly.Domain.Entities;
using Bultenly.Sql.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bultenly.Sql.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContentSource> ContentSources { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContentSourceConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public static AppContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AppContext(optionsBuilder.Options);
        }
    }
}
