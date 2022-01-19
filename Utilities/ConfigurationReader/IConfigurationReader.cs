namespace CompanyName.ConfigurationManagement
{
    public interface IConfigurationReader
    {
        string GetAppSettingValueByKey(string key);
    }
}
