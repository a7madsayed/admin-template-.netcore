namespace CompanyName.ConfigurationManagement
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.CacheManagement;

    internal class DBConfigurationReader : IConfigurationReader
    {
        private const string ConfigurationKeyInCache = "SystemConfigurations";
        private readonly ICachingHelper _CachingHelper;
        private readonly DbContext _DbContext;
        private readonly string _ConfigurationStoreName;
        private readonly string _KeyName;
        private readonly string _ValueName;

        public DBConfigurationReader(DbContext dBContext,
            ICachingHelper cachingHelper,
            string configurationStoreName,
            string keyName,
            string valueName)
        {
            _DbContext = dBContext;
            _CachingHelper = cachingHelper;
            _ConfigurationStoreName = configurationStoreName;
            _KeyName = keyName;
            _ValueName = valueName;
            CacheConfigurations();
        }

        /// <summary>
        /// Get configuration value by key
        /// </summary>
        /// <param name="key">Key of configuration</param>
        /// <exception cref="KeyNotFoundException">For missing key</exception>
        /// <returns>Configuration value</returns>
        public string GetAppSettingValueByKey(string key)
        {
            var Configurations = _CachingHelper.Get<Dictionary<string, string>>(ConfigurationKeyInCache);

            if (Configurations.ContainsKey(key.ToString()))
            {
                var value = Configurations[key.ToString()];
                if (!string.IsNullOrEmpty(value))
                {
                    return Configurations[key.ToString()];
                }
            }

            throw new KeyNotFoundException($"A configuration key '{key}' doesn't exist.");
        }

        private void CacheConfigurations()
        {
            var Configurations = GetConfigurationsFromStore();

            if (!_CachingHelper.Contains(ConfigurationKeyInCache))
            {
                _CachingHelper.Set(ConfigurationKeyInCache, Configurations);
            }
        }

        private Dictionary<string, string> GetConfigurationsFromStore()
        {
            var returnConfigurations = new Dictionary<string, string>();

            var Configurations = GetConfigurationsDbSet().ToList();

            if (Configurations != null)
            {
                var type = _DbContext.Model.FindEntityType(_ConfigurationStoreName).ClrType;
                var keyProperty = type.GetProperty(_KeyName);
                var valueProperty = type.GetProperty(_ValueName);

                foreach (var setting in Configurations)
                {
                    var key = keyProperty.GetValue(setting).ToString();
                    var value = valueProperty.GetValue(setting).ToString();

                    returnConfigurations.Add(key, value);
                }
            }

            return returnConfigurations;
        }

        private IQueryable<object> GetConfigurationsDbSet()
        {
            var entityType = _DbContext.Model.FindEntityType(_ConfigurationStoreName).ClrType;

            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set)).MakeGenericMethod(entityType);

            return (IQueryable<object>)setMethod.Invoke(_DbContext, null);
        }
    }
}
