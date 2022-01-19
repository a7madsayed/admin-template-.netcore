namespace CompanyName.Identity.Core
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IIdentityInitializer
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration, string connectionStringName);
    }
}
