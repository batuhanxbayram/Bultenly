// Infrastructure\Bultenly.Sql\Extensions\DbContextOptionsBuilderExtensions.cs
using Bultenly.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppContext = Bultenly.Sql.Context.AppContext;

namespace Bultenly.Sql.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static IServiceCollection AddSqlServerDbContext(this IServiceCollection services, string connectionString)   
        {
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}