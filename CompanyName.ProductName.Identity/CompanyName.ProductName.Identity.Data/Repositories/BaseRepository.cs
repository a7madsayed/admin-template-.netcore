namespace CompanyName.Identity.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected IdentityDbContext DbContext { get; }

        public BaseRepository(IdentityDbContext dbContext) => DbContext = dbContext;

        protected int SaveChanges(bool saveChanges = true)
        {
            if (saveChanges)
            {
                return DbContext.SaveChanges();
            }

            return 0;
        }
    }
}
