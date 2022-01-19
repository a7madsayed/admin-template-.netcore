namespace CompanyName.ProductName.Admin.Data.Dataseed.Security
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;
    using CompanyName.ProductName.Admin.Data.Entities;
    using CompanyName.ProductName.Admin.Core.Security;
    using CompanyName.ProductName.Admin.Core;

    public class SystemResourcesSeed : SeedBase<SystemResource>
    {
        private ApplicationDBContext _DbContext;
        private Translator _Translator;

        public override void SeedData(ApplicationDBContext dbContext)
        {
            _DbContext = dbContext;
            _Translator = new Translator(dbContext);

            AddOrUpdate(GetAll());
            _DbContext.SaveChanges();

        }

        private void AddOrUpdate(SystemResourceLocalizable[] entities)
        {
            foreach (var entity in entities)
            {
                var element = EnsureEntity(entity);

                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.English, entity.EnglishTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.Arabic, entity.ArabicTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.French, entity.FrenchTranslation);
            }
        }

        private SystemResource EnsureEntity(SystemResourceLocalizable resource)
        {
            var element = _DbContext.SystemResources.AsNoTracking().FirstOrDefault(p => p.Id == resource.SystemResourceObj.Id);

            if (element == null)
            {
                element = new SystemResource
                {
                    Id = resource.SystemResourceObj.Id,
                    IsActive = true,
                    IdentityName = resource.SystemResourceObj.IdentityName
                };

                _DbContext.SystemResources.Add(element);
            }
            else
            {
                element.IdentityName = resource.SystemResourceObj.IdentityName;
                element.IsActive = resource.SystemResourceObj.IsActive;
            }

            _Translator.Translate(element, e => e.NameTranslation, resource.SystemResourceObj.IdentityName);

            return element;
        }

        private SystemResourceLocalizable[] GetAll() => new SystemResourceLocalizable[]
            {
                new SystemResourceLocalizable
                {
                    SystemResourceObj = new SystemResource
                    {
                        Id = (int)Resource.Trip,
                        IdentityName = Resource.Trip.ToString(),
                        IsActive = true
                    },
                    ArabicTranslation = "Trip",
                    EnglishTranslation = "Trip",
                    FrenchTranslation = "Trip"
                }
            };

        private class SystemResourceLocalizable
        {
            public SystemResource SystemResourceObj { get; set; }

            public string EnglishTranslation { get; set; }

            public string ArabicTranslation { get; set; }

            public string FrenchTranslation { get; set; }
        }
    }
}
