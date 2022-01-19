namespace CompanyName.ProductName.Admin.Core.Configuration
{
    public interface IApplicationConfiguration
    {
        string GetAppSettingValueByKey(AppSettingData key);
    }
}
