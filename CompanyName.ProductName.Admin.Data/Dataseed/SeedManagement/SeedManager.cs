namespace CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement
{
    using System;

    internal class SeedManager<T>
    {
        internal static void SeedData(ApplicationDBContext dbContext)
        {
            var seedInstance = Activator.CreateInstance<T>();
            var method = typeof(T).GetMethod("SeedData");
            
            var result = method.Invoke(seedInstance, new object[] { dbContext });
        }
    }
}
