using AggregateRoot.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AggregateRoot.Data.Extensions
{
    public static class ContextExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString, string migrationAssemblyName)
        {
            services.AddDbContext<AggregateRootContext>(options => {
                options.UseSqlServer(connectionString, sql => {
                    sql.MigrationsAssembly(migrationAssemblyName);
                    sql.CommandTimeout(300);
                });
            });
        }

        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AggregateRootContext>(options => {
                options.UseSqlServer(connectionString, sql => {
                    sql.CommandTimeout(300);
                });
            });
        }
    }
}
