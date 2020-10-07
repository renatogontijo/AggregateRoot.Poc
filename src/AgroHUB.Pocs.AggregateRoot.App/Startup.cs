using AggregateRoot.Data.Context;
using AggregateRoot.Data.Extensions;
using AggregateRoot.Data.Repositories;
using AggregateRoot.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AggregateRoot.App
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables("AGROHUB_DEVELOPMENT_");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyName = typeof(Startup).Assembly.GetName().Name;

            services.AddDatabase(Configuration["DB_TST"], assemblyName);

            services.TryAddScoped<AggregateRootContext>();

            services.TryAddScoped<IFarmAreaRepository, FarmAreaRepository>();
            
            services.TryAddScoped<FarmAreaService>();
        }
    }
}
