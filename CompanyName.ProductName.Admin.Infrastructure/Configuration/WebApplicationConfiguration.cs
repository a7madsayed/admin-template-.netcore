namespace CompanyName.ProductName.Admin.Infrastructure.Configuration
{
    using CompanyName.ConfigurationManagement;
    using CompanyName.ProductName.Admin.Core.Configuration;
    using CompanyName.ProductName.Admin.Core.DataStore;

    public class WebApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IDBContextProvider _DbContextProvider;

        public WebApplicationConfiguration(IDBContextProvider dbContextProvider) => _DbContextProvider = dbContextProvider;

        public string GetAppSettingValueByKey(AppSettingData key)
        {
            var configurationReader = ConfigurationReaderProvider.GetConfigurationReader(StoreTypes.Database, _DbContextProvider.CurrentDBContext, "CompanyName.ProductName.Admin.Data.Entities.Setting", "Key", "Value");

            var r = configurationReader.GetAppSettingValueByKey(key.ToString());

            return r;
            //var settings = _cachingHelper.Get<Dictionary<string, string>>(SettingsKeyInCache);

            //if (settings.ContainsKey(key.ToString()))
            //{
            //    var value = settings[key.ToString()];
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        return settings[key.ToString()];
            //    }
            //}

            //throw new KeyNotFoundException($"A configuration key '{key}' doesn't exist.");
        }
    }
}
