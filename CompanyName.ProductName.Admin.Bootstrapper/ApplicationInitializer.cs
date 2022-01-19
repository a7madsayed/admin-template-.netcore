namespace CompanyName.ProductName.Admin.Bootstrapper
{
    using CompanyName.Identity.Bootstrapper;
    using CompanyName.ProductName.Admin.Core.Configuration;
    using CompanyName.ProductName.Admin.Core.DataStore;
    using CompanyName.ProductName.Admin.Core.Initialization;
    using CompanyName.ProductName.Admin.Data;
    using CompanyName.ProductName.Admin.Infrastructure.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationInitializer : IApplicationInitializer
    {
        public void ConfigureServices(IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName)
        {
            services.AddDbContext<ApplicationDBContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString(connectionStringName)));

            services.AddScoped<IDataStoreInitializer, DataStoreInitializer>();

            new IdentityInitializer().ConfigureServices(services, configuration, connectionStringName);

            services.AddScoped(typeof(IApplicationConfiguration), typeof(WebApplicationConfiguration));

            services.AddScoped(typeof(IDBContextProvider), typeof(DBContextProvider));
        }
    }
}
