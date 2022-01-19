namespace CompanyName.ProductName.Admin.Data
{
    using CompanyName.ProductName.Admin.Core.DataStore;
    using CompanyName.ProductName.Admin.Data.Dataseed;

    public class DataStoreInitializer : IDataStoreInitializer
    {
        private readonly ApplicationDBContext _DbContext;

        public DataStoreInitializer(ApplicationDBContext dbContext) => _DbContext = dbContext;

        public void Initialize() => SeedRunner.StartSeed(_DbContext);
    }
}
