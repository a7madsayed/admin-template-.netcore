namespace CompanyName.ConfigurationManagement
{
    using Microsoft.EntityFrameworkCore;
    using CompanyName.CacheManagement;

    public static class ConfigurationReaderProvider
    {
        private static IConfigurationReader _DBConfigurationReader;

        public static IConfigurationReader GetConfigurationReader(
            StoreTypes storeType,
            DbContext dbContext,
            string configurationStoreName,
            string keyName,
            string valueName)
        {
            switch (storeType)
            {
                case StoreTypes.Database:
                    return GetDBConfigurationReaderProvider(
                        dbContext,
                        configurationStoreName,
                        keyName,
                        valueName);
                default:
                    return GetDBConfigurationReaderProvider(
                        dbContext,
                        configurationStoreName,
                        keyName,
                        valueName);
            }
        }

        private static IConfigurationReader GetDBConfigurationReaderProvider(
            DbContext dbContext,
            string configurationStoreName,
            string keyName,
            string valueName)
        {
            if (_DBConfigurationReader == null)
            {
                _DBConfigurationReader = new DBConfigurationReader(dbContext, CachingProvider.GetCachingProvider(CachingTypes.Memory), configurationStoreName, keyName, valueName);
            }

            return _DBConfigurationReader;
        }
    }
}
