namespace CompanyName.ProductName.Admin.Core.DataStore
{
    using Microsoft.EntityFrameworkCore;

    public interface IDBContextProvider
    {
        DbContext CurrentDBContext { get; }
    }
}
