namespace CompanyName.ProductName.Admin.Data.Dataseed
{
    using CompanyName.ProductName.Admin.Data.Dataseed.CountryManagement;
    using CompanyName.ProductName.Admin.Data.Dataseed.Currencies;
    using CompanyName.ProductName.Admin.Data.Dataseed.Localization;
    using CompanyName.ProductName.Admin.Data.Dataseed.Security;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;
    using CompanyName.ProductName.Admin.Data.Dataseed.Settings;

    internal class SeedRunner
    {
        internal static void StartSeed(ApplicationDBContext dbContext)
        {
            SeedManager<LanguagesSeed>.SeedData(dbContext);
            SeedManager<PermissionsSeed>.SeedData(dbContext);
            SeedManager<SystemResourcesSeed>.SeedData(dbContext);
            SeedManager<CurrenciesSeed>.SeedData(dbContext);
            SeedManager<CountriesSeed>.SeedData(dbContext);
            SeedManager<SettingsSeed>.SeedData(dbContext);
        }
    }
}
