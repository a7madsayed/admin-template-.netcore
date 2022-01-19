namespace CompanyName.ProductName.Admin.Core.Initialization
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IApplicationInitializer
    {
        void ConfigureServices(IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName);
    }
}
