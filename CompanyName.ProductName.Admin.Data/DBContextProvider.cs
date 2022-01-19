namespace CompanyName.ProductName.Admin.Data
{
    using CompanyName.ProductName.Admin.Core.DataStore;
    using Microsoft.EntityFrameworkCore;

    public class DBContextProvider : IDBContextProvider
    {
        private readonly ApplicationDBContext _DbContext;

        public DBContextProvider(ApplicationDBContext dbContext) => _DbContext = dbContext;

        public DbContext CurrentDBContext => _DbContext;
    }
}
