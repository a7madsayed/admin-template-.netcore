namespace CompanyName.ProductName.Admin.Data.Dataseed.Settings
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;

    public class SettingsSeed : SeedBase<Entities.Setting>
    {
        private ApplicationDBContext _DbContext;

        public override void SeedData(ApplicationDBContext dbContext)
        {
            _DbContext = dbContext;

            AddOrUpdate(GetAll());

            _DbContext.SaveChanges();
        }

        private void AddOrUpdate(Entities.Setting[] entities)
        {
            foreach (var entity in entities)
            {
                var element = EnsureEntity(entity);
            }
        }

        private Entities.Setting EnsureEntity(Entities.Setting setting)
        {
            var element = _DbContext.Settings.AsNoTracking().FirstOrDefault(p => p.Key == setting.Key);

            if (element == null)
            {
                element = new Entities.Setting
                {
                    Key = setting.Key,
                    Value = setting.Value,
                    CreatedDate = DateTime.Now
                };

                _DbContext.Settings.Add(element);
            }

            return element;
        }

        private Entities.Setting[] GetAll() => new Entities.Setting[]
            {
                new Entities.Setting
                {
                    Key = "MailFrom",
                    Value = "mail1@gmail.com"
                },
                new Entities.Setting
                {
                    Key = "MailUserName",
                    Value = "mail2@gmail.com"
                }
            };
    }
}
