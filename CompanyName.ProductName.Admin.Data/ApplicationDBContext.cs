namespace CompanyName.ProductName.Admin.Data
{
    using System.IO;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using CompanyName.ProductName.Admin.Data.Entities;

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<SystemResource> SystemResources { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Translation> Translations { get; set; }

        public virtual DbSet<TranslationEntry> TranslationEntries { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Setting> Settings { get; set; }

        internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
        {
            public ApplicationDBContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationDBContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                builder.UseSqlServer(connectionString);

                return new ApplicationDBContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TranslationEntry>(entity =>
            {
                entity.HasKey(e => new { e.TranslationId, e.LanguageId });

                entity.HasIndex(e => new { e.TranslationId, e.LanguageId });
            });

            builder.Entity<CurrencyExchangeRate>(entity =>
            {
                entity.HasKey(e => new { e.FromCurrencyId, e.ToCurrencyId});

                entity.HasIndex(e => new { e.FromCurrencyId, e.ToCurrencyId });
            });

            builder.Entity<Setting>().HasKey(p => new { p.Key });

            RemoveCascadeDelete(builder);
        }

        private void RemoveCascadeDelete(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes().
                SelectMany(t => t.GetForeignKeys()).
                Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
