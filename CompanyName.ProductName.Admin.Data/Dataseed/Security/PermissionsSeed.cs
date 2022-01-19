namespace CompanyName.ProductName.Admin.Data.Dataseed.Security
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;
    using CompanyName.ProductName.Admin.Core;

    public class PermissionsSeed : SeedBase<Entities.Permission>
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

        private void AddOrUpdate(PermissionLocalizable[] entities)
        {
            foreach (var entity in entities)
            {
                var element = EnsureEntity(entity);

                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.English, entity.NameEnglishTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.Arabic, entity.NameArabicTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.French, entity.NameFrenchTranslation);
            }
        }

        private Entities.Permission EnsureEntity(PermissionLocalizable permission)
        {
            var element = _DbContext.Permissions.AsNoTracking().FirstOrDefault(p => p.Id == permission.PermissionObj.Id);

            if (element == null)
            {
                element = new Entities.Permission
                {
                    Id = permission.PermissionObj.Id,
                    IsActive = true,
                    IdentityName = permission.PermissionObj.IdentityName
                };

                _DbContext.Permissions.Add(element);
            }
            else
            {
                element.IdentityName = permission.PermissionObj.IdentityName;
                element.IsActive = permission.PermissionObj.IsActive;
            }

            _Translator.Translate(element, e => e.NameTranslation, permission.PermissionObj.IdentityName);

            return element;
        }

        private PermissionLocalizable[] GetAll() => new PermissionLocalizable[]
            {
                new PermissionLocalizable
                {
                    PermissionObj = new Entities.Permission
                    {
                        Id = (int)Core.Security.Permission.Read,
                        IdentityName = Core.Security.Permission.Read.ToString(),
                        IsActive = true
                    },
                    NameArabicTranslation = "قراءة",
                    NameEnglishTranslation = "Read",
                    NameFrenchTranslation = "lecture"
                },
                new PermissionLocalizable
                {
                    PermissionObj = new Entities.Permission
                    {
                        Id = (int)Core.Security.Permission.Add,
                        IdentityName = Core.Security.Permission.Add.ToString(),
                        IsActive = true
                    },
                    NameArabicTranslation = "اضافة",
                    NameEnglishTranslation = "Add",
                    NameFrenchTranslation = "ajouter"
                },
                new PermissionLocalizable
                {
                    PermissionObj = new Entities.Permission
                    {
                        Id = (int)Core.Security.Permission.Edit,
                        IdentityName = Core.Security.Permission.Edit.ToString(),
                        IsActive = true
                    },
                    NameArabicTranslation = "تعديل",
                    NameEnglishTranslation = "Edit",
                    NameFrenchTranslation = "Modification"
                },
                new PermissionLocalizable
                {
                    PermissionObj = new Entities.Permission
                    {
                        Id = (int)Core.Security.Permission.Delete,
                        IdentityName = Core.Security.Permission.Delete.ToString(),
                        IsActive = true
                    },
                    NameArabicTranslation = "حذف",
                    NameEnglishTranslation = "Delete",
                    NameFrenchTranslation = "Effacer"
                }
            };

        private class PermissionLocalizable
        {
            public Entities.Permission PermissionObj { get; set; }

            public string NameEnglishTranslation { get; set; }

            public string NameArabicTranslation { get; set; }

            public string NameFrenchTranslation { get; set; }
        }
    }
}
