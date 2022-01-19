namespace CompanyName.Identity.Bootstrapper
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CompanyName.Identity.Business.Stores;
    using CompanyName.Identity.Core;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;
    using CompanyName.Identity.Data;
    using CompanyName.Identity.Data.Repositories;
    using CompanyName.Identity.Infrastructure.Notification;

    public class IdentityInitializer : IIdentityInitializer
    {
        public void ConfigureServices(IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName)
        {
            services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, CustomRoleStore>();
            services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddSingleton(typeof(IEmailSender), typeof(EmailSender));
            services.AddDbContext<IdentityDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString(connectionStringName)));
            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<IdentityDbContext>();

            InitializeMapping();
        }

        private void InitializeMapping() => Mapper.Initialize(cfg => cfg.AddProfiles("CompanyName.Identity.Data"));
    }
}
