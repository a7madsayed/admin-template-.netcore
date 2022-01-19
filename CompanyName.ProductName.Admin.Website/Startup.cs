using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CompanyName.ProductName.Admin.Website.Security;
using Swashbuckle.AspNetCore.Swagger;
using CompanyName.ProductName.Admin.Extensions.Exceptions;
using CompanyName.ProductName.Admin.Core.Exceptions;
using CompanyName.ProductName.Admin.Core.Initialization;
using CompanyName.ProductName.Admin.Core.DataStore;

namespace CompanyName.ProductName.Admin.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            InitializeSecurityServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthorization();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Admin", Version = "v1" });
            });

            InitializeApplication(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseAspNetCoreExceptionHandler();
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            SetupLoggingOnAzure(loggerFactory);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin V1");
            });

            app.UseAuthentication();

            app.UseMvc();

            InitializeDataStore(app);
        }

        private void InitializeApplication(IServiceCollection services)
        {
            var initializerType = Configuration.GetValue<string>("InitializerType");
            var assembliesSection = Configuration.GetSection("StartupAssemblies");
            var startupAssemblies = assembliesSection.AsEnumerable();
            var rootDirectory = GetAssemblyFolder();

            //Load startup Assemblies
            foreach (var assembly in startupAssemblies)
            {
                if (!string.IsNullOrWhiteSpace(assembly.Value))
                {
                    LoadAssembly($@"{rootDirectory}\{assembly.Value}");
                }
            }

            // Load Bootstapper Assembly
            var initializerAssembly = initializerType.Split(',')[0];
            var initializerName = initializerType.Split(',')[1];
            var assemblyBootstapper = LoadAssembly($@"{rootDirectory}\{initializerAssembly}");

            var type = assemblyBootstapper.GetType(initializerName);
            if (type == null)
            {
                throw new MissingConfigurationKeyException("Could not find initializer type");
            }

            if (!( Activator.CreateInstance(type) is IApplicationInitializer initializer ))
            {
                throw new InvalidOperationException("Could not load/create initializer");
            }

            // Start initialization
            initializer.ConfigureServices(services, Configuration, "DefaultConnection");
        }

        private Assembly LoadAssembly(string assemblyPath) => AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);

        private string GetAssemblyFolder()
        {
            var currentAssemblyPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var splitterIndex = currentAssemblyPath.LastIndexOf('\\');
            return currentAssemblyPath.Substring(0, splitterIndex);
        }

        private void SetupLoggingOnAzure(ILoggerFactory loggerFactory)
        {
            var LogInAzure = Configuration.GetValue<string>("LogOnAzure");

            if (bool.TryParse(LogInAzure, out var value))
            {
                if (value)
                {
                    loggerFactory.AddDebug();
                    loggerFactory.AddAzureWebAppDiagnostics();
                }
            }
        }

        private void InitializeDataStore(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<IDataStoreInitializer>().Initialize();
            }
        }

        private void InitializeSecurityServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorizationPolicyProvider, PermissionToAccessResourcePolicy>();
            services.AddSingleton<IAuthorizationHandler, PermissionToAccessResourceAuthorizationHandler>();
        }
    }
}
