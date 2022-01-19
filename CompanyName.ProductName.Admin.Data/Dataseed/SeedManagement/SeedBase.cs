namespace CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement
{
    public abstract class SeedBase<T>
    {
        public abstract void SeedData(ApplicationDBContext dbContext);
    }
}
