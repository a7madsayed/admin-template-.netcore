namespace CompanyName.ProductName.Admin.Data.Dataseed.Currencies
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;
    using CompanyName.ProductName.Admin.Data.Entities;
    using CompanyName.ProductName.Admin.Core;

    public class CurrenciesSeed : SeedBase<Currency>
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

        private void AddOrUpdate(CurrencyLocalizable[] entities)
        {
            foreach (var entity in entities)
            {
                var element = EnsureEntity(entity);

                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.English, entity.NameEnglishTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.Arabic, entity.NameArabicTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.French, entity.NameFrenchTranslation);

                _Translator.Translate(element, l => l.CodeTranslation, SupportedLanguages.English, entity.CodeEnglishTranslation);
                _Translator.Translate(element, l => l.CodeTranslation, SupportedLanguages.Arabic, entity.CodeArabicTranslation);
                _Translator.Translate(element, l => l.CodeTranslation, SupportedLanguages.French, entity.CodeFrenchTranslation);

                _Translator.Translate(element, l => l.UnitNameTranslation, SupportedLanguages.English, entity.UnitNameEnglishTranslation);
                _Translator.Translate(element, l => l.UnitNameTranslation, SupportedLanguages.Arabic, entity.UnitNameArabicTranslation);
                _Translator.Translate(element, l => l.UnitNameTranslation, SupportedLanguages.French, entity.UnitNameFrenchTranslation);

                _Translator.Translate(element, l => l.PluralNameTranslation, SupportedLanguages.English, entity.PluralNameEnglishTranslation);
                _Translator.Translate(element, l => l.PluralNameTranslation, SupportedLanguages.Arabic, entity.PluralNameArabicTranslation);
                _Translator.Translate(element, l => l.PluralNameTranslation, SupportedLanguages.French, entity.PluralNameFrenchTranslation);

                _Translator.Translate(element, l => l.PluralUnitNameTranslation, SupportedLanguages.English, entity.PluralUnitNameEnglishTranslation);
                _Translator.Translate(element, l => l.PluralUnitNameTranslation, SupportedLanguages.Arabic, entity.PluralUnitNameArabicTranslation);
                _Translator.Translate(element, l => l.PluralUnitNameTranslation, SupportedLanguages.French, entity.PluralUnitNameFrenchTranslation);
            }
        }

        private Currency EnsureEntity(CurrencyLocalizable currency)
        {
            var element = _DbContext.Currencies.AsNoTracking().FirstOrDefault(p => p.Id == currency.CurrencyObj.Id);

            if (element == null)
            {
                element = new Currency
                {
                    Id = currency.CurrencyObj.Id,
                    Code = currency.CurrencyObj.Code,
                    IsActive = currency.CurrencyObj.IsActive,
                    IsNameFeminine = currency.CurrencyObj.IsNameFeminine,
                    IsUnitNameFeminine = currency.CurrencyObj.IsUnitNameFeminine,
                    UnitPrecision = currency.CurrencyObj.UnitPrecision
                };

                _DbContext.Currencies.Add(element);
            }
            else
            {
                element.Code = currency.CurrencyObj.Code;
                element.IsActive = currency.CurrencyObj.IsActive;
                element.IsNameFeminine = currency.CurrencyObj.IsNameFeminine;
                element.IsUnitNameFeminine = currency.CurrencyObj.IsUnitNameFeminine;
                element.UnitPrecision = currency.CurrencyObj.UnitPrecision;
            }

            _Translator.Translate(element, e => e.NameTranslation, currency.NameEnglishTranslation);
            _Translator.Translate(element, e => e.CodeTranslation, currency.CodeEnglishTranslation);
            _Translator.Translate(element, e => e.UnitNameTranslation, currency.UnitNameEnglishTranslation);
            _Translator.Translate(element, e => e.PluralNameTranslation, currency.PluralNameEnglishTranslation);
            _Translator.Translate(element, e => e.PluralUnitNameTranslation, currency.PluralUnitNameEnglishTranslation);

            return element;
        }

        private CurrencyLocalizable[] GetAll() =>                 new CurrencyLocalizable[]
            {
                                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 1,
                        Code = "AFN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Afghanistan Afghani",
                    NameEnglishTranslation = "Afghanistan Afghani",
                    NameFrenchTranslation = "Afghanistan Afghani",

                    CodeArabicTranslation = "AFN",
                    CodeEnglishTranslation = "AFN",
                    CodeFrenchTranslation = "AFN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 2,
                        Code = "ALL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Albanian Lek",
                    NameEnglishTranslation = "Albanian Lek",
                    NameFrenchTranslation = "Albanian Lek",

                    CodeArabicTranslation = "ALL",
                    CodeEnglishTranslation = "ALL",
                    CodeFrenchTranslation = "ALL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 3,
                        Code = "DZD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Algerian Dinar",
                    NameEnglishTranslation = "Algerian Dinar",
                    NameFrenchTranslation = "Algerian Dinar",

                    CodeArabicTranslation = "DZD",
                    CodeEnglishTranslation = "DZD",
                    CodeFrenchTranslation = "DZD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 4,
                        Code = "AOA",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Angolan Kwanza",
                    NameEnglishTranslation = "Angolan Kwanza",
                    NameFrenchTranslation = "Angolan Kwanza",

                    CodeArabicTranslation = "AOA",
                    CodeEnglishTranslation = "AOA",
                    CodeFrenchTranslation = "AOA",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 5,
                        Code = "ARS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Argentine Peso",
                    NameEnglishTranslation = "Argentine Peso",
                    NameFrenchTranslation = "Argentine Peso",

                    CodeArabicTranslation = "ARS",
                    CodeEnglishTranslation = "ARS",
                    CodeFrenchTranslation = "ARS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 6,
                        Code = "AMD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Armenian Dram",
                    NameEnglishTranslation = "Armenian Dram",
                    NameFrenchTranslation = "Armenian Dram",

                    CodeArabicTranslation = "AMD",
                    CodeEnglishTranslation = "AMD",
                    CodeFrenchTranslation = "AMD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 7,
                        Code = "AWG",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Aruban Guilder",
                    NameEnglishTranslation = "Aruban Guilder",
                    NameFrenchTranslation = "Aruban Guilder",

                    CodeArabicTranslation = "AWG",
                    CodeEnglishTranslation = "AWG",
                    CodeFrenchTranslation = "AWG",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 8,
                        Code = "AUD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Australian Dollar",
                    NameEnglishTranslation = "Australian Dollar",
                    NameFrenchTranslation = "Australian Dollar",

                    CodeArabicTranslation = "AUD",
                    CodeEnglishTranslation = "AUD",
                    CodeFrenchTranslation = "AUD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 9,
                        Code = "AZN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Azerbaijanian Manat",
                    NameEnglishTranslation = "Azerbaijanian Manat",
                    NameFrenchTranslation = "Azerbaijanian Manat",

                    CodeArabicTranslation = "AZN",
                    CodeEnglishTranslation = "AZN",
                    CodeFrenchTranslation = "AZN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 10,
                        Code = "BSD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bahamian Dollar",
                    NameEnglishTranslation = "Bahamian Dollar",
                    NameFrenchTranslation = "Bahamian Dollar",

                    CodeArabicTranslation = "BSD",
                    CodeEnglishTranslation = "BSD",
                    CodeFrenchTranslation = "BSD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 11,
                        Code = "BHD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Bahraini Dinar",
                    NameEnglishTranslation = "Bahraini Dinar",
                    NameFrenchTranslation = "Bahraini Dinar",

                    CodeArabicTranslation = "BHD",
                    CodeEnglishTranslation = "BHD",
                    CodeFrenchTranslation = "BHD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 12,
                        Code = "BDT",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bangladesh Taka",
                    NameEnglishTranslation = "Bangladesh Taka",
                    NameFrenchTranslation = "Bangladesh Taka",

                    CodeArabicTranslation = "BDT",
                    CodeEnglishTranslation = "BDT",
                    CodeFrenchTranslation = "BDT",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 13,
                        Code = "BBD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Barbados Dollar",
                    NameEnglishTranslation = "Barbados Dollar",
                    NameFrenchTranslation = "Barbados Dollar",

                    CodeArabicTranslation = "BBD",
                    CodeEnglishTranslation = "BBD",
                    CodeFrenchTranslation = "BBD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 14,
                        Code = "BYR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Belarussian Ruble",
                    NameEnglishTranslation = "Belarussian Ruble",
                    NameFrenchTranslation = "Belarussian Ruble",

                    CodeArabicTranslation = "BYR",
                    CodeEnglishTranslation = "BYR",
                    CodeFrenchTranslation = "BYR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 15,
                        Code = "BZD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Belize Dollar",
                    NameEnglishTranslation = "Belize Dollar",
                    NameFrenchTranslation = "Belize Dollar",

                    CodeArabicTranslation = "BZD",
                    CodeEnglishTranslation = "BZD",
                    CodeFrenchTranslation = "BZD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 16,
                        Code = "BMD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bermudian Dollar",
                    NameEnglishTranslation = "Bermudian Dollar",
                    NameFrenchTranslation = "Bermudian Dollar",

                    CodeArabicTranslation = "BMD",
                    CodeEnglishTranslation = "BMD",
                    CodeFrenchTranslation = "BMD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 17,
                        Code = "BTN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bhutan Ngultrum",
                    NameEnglishTranslation = "Bhutan Ngultrum",
                    NameFrenchTranslation = "Bhutan Ngultrum",

                    CodeArabicTranslation = "BTN",
                    CodeEnglishTranslation = "BTN",
                    CodeFrenchTranslation = "BTN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 18,
                        Code = "BOB",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bolivian Boliviano",
                    NameEnglishTranslation = "Bolivian Boliviano",
                    NameFrenchTranslation = "Bolivian Boliviano",

                    CodeArabicTranslation = "BOB",
                    CodeEnglishTranslation = "BOB",
                    CodeFrenchTranslation = "BOB",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 19,
                        Code = "BOV",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bolivian Mvdol",
                    NameEnglishTranslation = "Bolivian Mvdol",
                    NameFrenchTranslation = "Bolivian Mvdol",

                    CodeArabicTranslation = "BOV",
                    CodeEnglishTranslation = "BOV",
                    CodeFrenchTranslation = "BOV",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 20,
                        Code = "BAM",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bosnia and Herzegovina Convertible Marks",
                    NameEnglishTranslation = "Bosnia and Herzegovina Convertible Marks",
                    NameFrenchTranslation = "Bosnia and Herzegovina Convertible Marks",

                    CodeArabicTranslation = "BAM",
                    CodeEnglishTranslation = "BAM",
                    CodeFrenchTranslation = "BAM",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 21,
                        Code = "BWP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Botswana Pula",
                    NameEnglishTranslation = "Botswana Pula",
                    NameFrenchTranslation = "Botswana Pula",

                    CodeArabicTranslation = "BWP",
                    CodeEnglishTranslation = "BWP",
                    CodeFrenchTranslation = "BWP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 22,
                        Code = "BRL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Brazilian Real",
                    NameEnglishTranslation = "Brazilian Real",
                    NameFrenchTranslation = "Brazilian Real",

                    CodeArabicTranslation = "BRL",
                    CodeEnglishTranslation = "BRL",
                    CodeFrenchTranslation = "BRL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 23,
                        Code = "BND",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Brunei Dollar",
                    NameEnglishTranslation = "Brunei Dollar",
                    NameFrenchTranslation = "Brunei Dollar",

                    CodeArabicTranslation = "BND",
                    CodeEnglishTranslation = "BND",
                    CodeFrenchTranslation = "BND",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 24,
                        Code = "BGN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Bulgarian Lev",
                    NameEnglishTranslation = "Bulgarian Lev",
                    NameFrenchTranslation = "Bulgarian Lev",

                    CodeArabicTranslation = "BGN",
                    CodeEnglishTranslation = "BGN",
                    CodeFrenchTranslation = "BGN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 25,
                        Code = "BIF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Burundi Franc",
                    NameEnglishTranslation = "Burundi Franc",
                    NameFrenchTranslation = "Burundi Franc",

                    CodeArabicTranslation = "BIF",
                    CodeEnglishTranslation = "BIF",
                    CodeFrenchTranslation = "BIF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 26,
                        Code = "CVE",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Cabo Verde Escudo",
                    NameEnglishTranslation = "Cabo Verde Escudo",
                    NameFrenchTranslation = "Cabo Verde Escudo",

                    CodeArabicTranslation = "CVE",
                    CodeEnglishTranslation = "CVE",
                    CodeFrenchTranslation = "CVE",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 27,
                        Code = "KHR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Cambodia Riel",
                    NameEnglishTranslation = "Cambodia Riel",
                    NameFrenchTranslation = "Cambodia Riel",

                    CodeArabicTranslation = "KHR",
                    CodeEnglishTranslation = "KHR",
                    CodeFrenchTranslation = "KHR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 28,
                        Code = "CAD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Canadian Dollar",
                    NameEnglishTranslation = "Canadian Dollar",
                    NameFrenchTranslation = "Canadian Dollar",

                    CodeArabicTranslation = "CAD",
                    CodeEnglishTranslation = "CAD",
                    CodeFrenchTranslation = "CAD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 29,
                        Code = "KYD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Cayman Islands Dollar",
                    NameEnglishTranslation = "Cayman Islands Dollar",
                    NameFrenchTranslation = "Cayman Islands Dollar",

                    CodeArabicTranslation = "KYD",
                    CodeEnglishTranslation = "KYD",
                    CodeFrenchTranslation = "KYD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 30,
                        Code = "XOF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "CFA Franc BCEAO",
                    NameEnglishTranslation = "CFA Franc BCEAO",
                    NameFrenchTranslation = "CFA Franc BCEAO",

                    CodeArabicTranslation = "XOF",
                    CodeEnglishTranslation = "XOF",
                    CodeFrenchTranslation = "XOF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 31,
                        Code = "XAF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "CFA Franc BEAC",
                    NameEnglishTranslation = "CFA Franc BEAC",
                    NameFrenchTranslation = "CFA Franc BEAC",

                    CodeArabicTranslation = "XAF",
                    CodeEnglishTranslation = "XAF",
                    CodeFrenchTranslation = "XAF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 32,
                        Code = "XPF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "CFP Franc",
                    NameEnglishTranslation = "CFP Franc",
                    NameFrenchTranslation = "CFP Franc",

                    CodeArabicTranslation = "XPF",
                    CodeEnglishTranslation = "XPF",
                    CodeFrenchTranslation = "XPF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 33,
                        Code = "CLP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Chilean Peso",
                    NameEnglishTranslation = "Chilean Peso",
                    NameFrenchTranslation = "Chilean Peso",

                    CodeArabicTranslation = "CLP",
                    CodeEnglishTranslation = "CLP",
                    CodeFrenchTranslation = "CLP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 34,
                        Code = "CLF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 4
                    },
                    NameArabicTranslation = "Chilean Unidad de Fomento",
                    NameEnglishTranslation = "Chilean Unidad de Fomento",
                    NameFrenchTranslation = "Chilean Unidad de Fomento",

                    CodeArabicTranslation = "CLF",
                    CodeEnglishTranslation = "CLF",
                    CodeFrenchTranslation = "CLF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 35,
                        Code = "COU",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Chilean Unidad de Valor Real",
                    NameEnglishTranslation = "Chilean Unidad de Valor Real",
                    NameFrenchTranslation = "Chilean Unidad de Valor Real",

                    CodeArabicTranslation = "COU",
                    CodeEnglishTranslation = "COU",
                    CodeFrenchTranslation = "COU",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 36,
                        Code = "CNY",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Chinese Yuan Renminbi",
                    NameEnglishTranslation = "Chinese Yuan Renminbi",
                    NameFrenchTranslation = "Chinese Yuan Renminbi",

                    CodeArabicTranslation = "CNY",
                    CodeEnglishTranslation = "CNY",
                    CodeFrenchTranslation = "CNY",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 37,
                        Code = "COP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Colombian Peso",
                    NameEnglishTranslation = "Colombian Peso",
                    NameFrenchTranslation = "Colombian Peso",

                    CodeArabicTranslation = "COP",
                    CodeEnglishTranslation = "COP",
                    CodeFrenchTranslation = "COP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 38,
                        Code = "KMF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Comoro Franc",
                    NameEnglishTranslation = "Comoro Franc",
                    NameFrenchTranslation = "Comoro Franc",

                    CodeArabicTranslation = "KMF",
                    CodeEnglishTranslation = "KMF",
                    CodeFrenchTranslation = "KMF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 39,
                        Code = "CDF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Congolese Franc",
                    NameEnglishTranslation = "Congolese Franc",
                    NameFrenchTranslation = "Congolese Franc",

                    CodeArabicTranslation = "CDF",
                    CodeEnglishTranslation = "CDF",
                    CodeFrenchTranslation = "CDF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 40,
                        Code = "CRC",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Costa Rican Colon",
                    NameEnglishTranslation = "Costa Rican Colon",
                    NameFrenchTranslation = "Costa Rican Colon",

                    CodeArabicTranslation = "CRC",
                    CodeEnglishTranslation = "CRC",
                    CodeFrenchTranslation = "CRC",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 41,
                        Code = "HRK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Croatian Kuna",
                    NameEnglishTranslation = "Croatian Kuna",
                    NameFrenchTranslation = "Croatian Kuna",

                    CodeArabicTranslation = "HRK",
                    CodeEnglishTranslation = "HRK",
                    CodeFrenchTranslation = "HRK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 42,
                        Code = "CUP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Cuban Peso",
                    NameEnglishTranslation = "Cuban Peso",
                    NameFrenchTranslation = "Cuban Peso",

                    CodeArabicTranslation = "CUP",
                    CodeEnglishTranslation = "CUP",
                    CodeFrenchTranslation = "CUP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 43,
                        Code = "CZK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Czech Koruna",
                    NameEnglishTranslation = "Czech Koruna",
                    NameFrenchTranslation = "Czech Koruna",

                    CodeArabicTranslation = "CZK",
                    CodeEnglishTranslation = "CZK",
                    CodeFrenchTranslation = "CZK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 44,
                        Code = "DKK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Danish Krone",
                    NameEnglishTranslation = "Danish Krone",
                    NameFrenchTranslation = "Danish Krone",

                    CodeArabicTranslation = "DKK",
                    CodeEnglishTranslation = "DKK",
                    CodeFrenchTranslation = "DKK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 45,
                        Code = "DJF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Djibouti Franc",
                    NameEnglishTranslation = "Djibouti Franc",
                    NameFrenchTranslation = "Djibouti Franc",

                    CodeArabicTranslation = "DJF",
                    CodeEnglishTranslation = "DJF",
                    CodeFrenchTranslation = "DJF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 46,
                        Code = "DOP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Dominican Peso",
                    NameEnglishTranslation = "Dominican Peso",
                    NameFrenchTranslation = "Dominican Peso",

                    CodeArabicTranslation = "DOP",
                    CodeEnglishTranslation = "DOP",
                    CodeFrenchTranslation = "DOP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 47,
                        Code = "XCD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "East Caribbean Dollar",
                    NameEnglishTranslation = "East Caribbean Dollar",
                    NameFrenchTranslation = "East Caribbean Dollar",

                    CodeArabicTranslation = "XCD",
                    CodeEnglishTranslation = "XCD",
                    CodeFrenchTranslation = "XCD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 48,
                        Code = "EGP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = true,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "جنيه المصرى",
                    NameEnglishTranslation = "Egyptian Pound",
                    NameFrenchTranslation = "Livre égyptienne",

                    CodeArabicTranslation = "جنيه",
                    CodeEnglishTranslation = "EGP",
                    CodeFrenchTranslation = "EGP",

                    UnitNameArabicTranslation = "قرش",
                    UnitNameEnglishTranslation = "Piastre",
                    UnitNameFrenchTranslation = "Piastre",

                    PluralNameArabicTranslation = "جنيهات",
                    PluralNameEnglishTranslation = "Pounds",
                    PluralNameFrenchTranslation = "Pounds",

                    PluralUnitNameArabicTranslation = "قروش",
                    PluralUnitNameEnglishTranslation = "Piastres",
                    PluralUnitNameFrenchTranslation = "Piastres",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 49,
                        Code = "SVC",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "El Salvador Colon",
                    NameEnglishTranslation = "El Salvador Colon",
                    NameFrenchTranslation = "El Salvador Colon",

                    CodeArabicTranslation = "SVC",
                    CodeEnglishTranslation = "SVC",
                    CodeFrenchTranslation = "SVC",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 50,
                        Code = "ERN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Eritrean Nafka",
                    NameEnglishTranslation = "Eritrean Nafka",
                    NameFrenchTranslation = "Eritrean Nafka",

                    CodeArabicTranslation = "ERN",
                    CodeEnglishTranslation = "ERN",
                    CodeFrenchTranslation = "ERN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 51,
                        Code = "ETB",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Ethiopian Birr",
                    NameEnglishTranslation = "Ethiopian Birr",
                    NameFrenchTranslation = "Ethiopian Birr",

                    CodeArabicTranslation = "ETB",
                    CodeEnglishTranslation = "ETB",
                    CodeFrenchTranslation = "ETB",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 52,
                        Code = "EUR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Euro",
                    NameEnglishTranslation = "Euro",
                    NameFrenchTranslation = "Euro",

                    CodeArabicTranslation = "EUR",
                    CodeEnglishTranslation = "EUR",
                    CodeFrenchTranslation = "EUR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 53,
                        Code = "FKP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Falkland Islands Pound",
                    NameEnglishTranslation = "Falkland Islands Pound",
                    NameFrenchTranslation = "Falkland Islands Pound",

                    CodeArabicTranslation = "FKP",
                    CodeEnglishTranslation = "FKP",
                    CodeFrenchTranslation = "FKP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 54,
                        Code = "FJD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Fiji Dollar",
                    NameEnglishTranslation = "Fiji Dollar",
                    NameFrenchTranslation = "Fiji Dollar",

                    CodeArabicTranslation = "FJD",
                    CodeEnglishTranslation = "FJD",
                    CodeFrenchTranslation = "FJD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 55,
                        Code = "GMD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Gambian Dalasi",
                    NameEnglishTranslation = "Gambian Dalasi",
                    NameFrenchTranslation = "Gambian Dalasi",

                    CodeArabicTranslation = "GMD",
                    CodeEnglishTranslation = "GMD",
                    CodeFrenchTranslation = "GMD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 56,
                        Code = "GEL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Georgian Lari",
                    NameEnglishTranslation = "Georgian Lari",
                    NameFrenchTranslation = "Georgian Lari",

                    CodeArabicTranslation = "GEL",
                    CodeEnglishTranslation = "GEL",
                    CodeFrenchTranslation = "GEL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 57,
                        Code = "GHS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Ghana Cedi",
                    NameEnglishTranslation = "Ghana Cedi",
                    NameFrenchTranslation = "Ghana Cedi",

                    CodeArabicTranslation = "GHS",
                    CodeEnglishTranslation = "GHS",
                    CodeFrenchTranslation = "GHS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 58,
                        Code = "GIP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Gibraltar Pound",
                    NameEnglishTranslation = "Gibraltar Pound",
                    NameFrenchTranslation = "Gibraltar Pound",

                    CodeArabicTranslation = "GIP",
                    CodeEnglishTranslation = "GIP",
                    CodeFrenchTranslation = "GIP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 59,
                        Code = "GTQ",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Guatemala Quetzal",
                    NameEnglishTranslation = "Guatemala Quetzal",
                    NameFrenchTranslation = "Guatemala Quetzal",

                    CodeArabicTranslation = "GTQ",
                    CodeEnglishTranslation = "GTQ",
                    CodeFrenchTranslation = "GTQ",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 60,
                        Code = "GNF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Guinea Franc",
                    NameEnglishTranslation = "Guinea Franc",
                    NameFrenchTranslation = "Guinea Franc",

                    CodeArabicTranslation = "GNF",
                    CodeEnglishTranslation = "GNF",
                    CodeFrenchTranslation = "GNF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 61,
                        Code = "GYD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Guyana Dollar",
                    NameEnglishTranslation = "Guyana Dollar",
                    NameFrenchTranslation = "Guyana Dollar",

                    CodeArabicTranslation = "GYD",
                    CodeEnglishTranslation = "GYD",
                    CodeFrenchTranslation = "GYD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 62,
                        Code = "HTG",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Haiti Gourde",
                    NameEnglishTranslation = "Haiti Gourde",
                    NameFrenchTranslation = "Haiti Gourde",

                    CodeArabicTranslation = "HTG",
                    CodeEnglishTranslation = "HTG",
                    CodeFrenchTranslation = "HTG",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 63,
                        Code = "HNL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Honduras Lempira",
                    NameEnglishTranslation = "Honduras Lempira",
                    NameFrenchTranslation = "Honduras Lempira",

                    CodeArabicTranslation = "HNL",
                    CodeEnglishTranslation = "HNL",
                    CodeFrenchTranslation = "HNL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 64,
                        Code = "HKD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Hong Kong Dollar",
                    NameEnglishTranslation = "Hong Kong Dollar",
                    NameFrenchTranslation = "Hong Kong Dollar",

                    CodeArabicTranslation = "HKD",
                    CodeEnglishTranslation = "HKD",
                    CodeFrenchTranslation = "HKD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 65,
                        Code = "HUF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Hungarian Forint",
                    NameEnglishTranslation = "Hungarian Forint",
                    NameFrenchTranslation = "Hungarian Forint",

                    CodeArabicTranslation = "HUF",
                    CodeEnglishTranslation = "HUF",
                    CodeFrenchTranslation = "HUF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 66,
                        Code = "ISK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Iceland Krona",
                    NameEnglishTranslation = "Iceland Krona",
                    NameFrenchTranslation = "Iceland Krona",

                    CodeArabicTranslation = "ISK",
                    CodeEnglishTranslation = "ISK",
                    CodeFrenchTranslation = "ISK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 67,
                        Code = "INR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Indian Rupee",
                    NameEnglishTranslation = "Indian Rupee",
                    NameFrenchTranslation = "Indian Rupee",

                    CodeArabicTranslation = "INR",
                    CodeEnglishTranslation = "INR",
                    CodeFrenchTranslation = "INR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 68,
                        Code = "IDR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Indonesian Rupiah",
                    NameEnglishTranslation = "Indonesian Rupiah",
                    NameFrenchTranslation = "Indonesian Rupiah",

                    CodeArabicTranslation = "IDR",
                    CodeEnglishTranslation = "IDR",
                    CodeFrenchTranslation = "IDR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 69,
                        Code = "IRR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Iranian Rial",
                    NameEnglishTranslation = "Iranian Rial",
                    NameFrenchTranslation = "Iranian Rial",

                    CodeArabicTranslation = "IRR",
                    CodeEnglishTranslation = "IRR",
                    CodeFrenchTranslation = "IRR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 70,
                        Code = "IQD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Iraqi Dinar",
                    NameEnglishTranslation = "Iraqi Dinar",
                    NameFrenchTranslation = "Iraqi Dinar",

                    CodeArabicTranslation = "IQD",
                    CodeEnglishTranslation = "IQD",
                    CodeFrenchTranslation = "IQD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 71,
                        Code = "JMD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Jamaican Dollar",
                    NameEnglishTranslation = "Jamaican Dollar",
                    NameFrenchTranslation = "Jamaican Dollar",

                    CodeArabicTranslation = "JMD",
                    CodeEnglishTranslation = "JMD",
                    CodeFrenchTranslation = "JMD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 72,
                        Code = "JPY",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Japanese Yen",
                    NameEnglishTranslation = "Japanese Yen",
                    NameFrenchTranslation = "Japanese Yen",

                    CodeArabicTranslation = "JPY",
                    CodeEnglishTranslation = "JPY",
                    CodeFrenchTranslation = "JPY",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 73,
                        Code = "JOD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Jordanian Dinar",
                    NameEnglishTranslation = "Jordanian Dinar",
                    NameFrenchTranslation = "Jordanian Dinar",

                    CodeArabicTranslation = "JOD",
                    CodeEnglishTranslation = "JOD",
                    CodeFrenchTranslation = "JOD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 74,
                        Code = "KZT",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Kazakhstan Tenge",
                    NameEnglishTranslation = "Kazakhstan Tenge",
                    NameFrenchTranslation = "Kazakhstan Tenge",

                    CodeArabicTranslation = "KZT",
                    CodeEnglishTranslation = "KZT",
                    CodeFrenchTranslation = "KZT",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 75,
                        Code = "KES",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Kenyan Shilling",
                    NameEnglishTranslation = "Kenyan Shilling",
                    NameFrenchTranslation = "Kenyan Shilling",

                    CodeArabicTranslation = "KES",
                    CodeEnglishTranslation = "KES",
                    CodeFrenchTranslation = "KES",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 76,
                        Code = "KRW",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Korean Won",
                    NameEnglishTranslation = "Korean Won",
                    NameFrenchTranslation = "Korean Won",

                    CodeArabicTranslation = "KRW",
                    CodeEnglishTranslation = "KRW",
                    CodeFrenchTranslation = "KRW",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 77,
                        Code = "KWD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Kuwaiti Dinar",
                    NameEnglishTranslation = "Kuwaiti Dinar",
                    NameFrenchTranslation = "Kuwaiti Dinar",

                    CodeArabicTranslation = "KWD",
                    CodeEnglishTranslation = "KWD",
                    CodeFrenchTranslation = "KWD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 78,
                        Code = "KGS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Kyrgyzstan Som",
                    NameEnglishTranslation = "Kyrgyzstan Som",
                    NameFrenchTranslation = "Kyrgyzstan Som",

                    CodeArabicTranslation = "KGS",
                    CodeEnglishTranslation = "KGS",
                    CodeFrenchTranslation = "KGS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 79,
                        Code = "LAK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Lao Kip",
                    NameEnglishTranslation = "Lao Kip",
                    NameFrenchTranslation = "Lao Kip",

                    CodeArabicTranslation = "LAK",
                    CodeEnglishTranslation = "LAK",
                    CodeFrenchTranslation = "LAK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 80,
                        Code = "LBP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Lebanese Pound",
                    NameEnglishTranslation = "Lebanese Pound",
                    NameFrenchTranslation = "Lebanese Pound",

                    CodeArabicTranslation = "LBP",
                    CodeEnglishTranslation = "LBP",
                    CodeFrenchTranslation = "LBP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 81,
                        Code = "LSL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Lesotho Loti",
                    NameEnglishTranslation = "Lesotho Loti",
                    NameFrenchTranslation = "Lesotho Loti",

                    CodeArabicTranslation = "LSL",
                    CodeEnglishTranslation = "LSL",
                    CodeFrenchTranslation = "LSL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 82,
                        Code = "LRD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Liberian Dollar",
                    NameEnglishTranslation = "Liberian Dollar",
                    NameFrenchTranslation = "Liberian Dollar",

                    CodeArabicTranslation = "LRD",
                    CodeEnglishTranslation = "LRD",
                    CodeFrenchTranslation = "LRD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 83,
                        Code = "LYD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Libyan Dinar",
                    NameEnglishTranslation = "Libyan Dinar",
                    NameFrenchTranslation = "Libyan Dinar",

                    CodeArabicTranslation = "LYD",
                    CodeEnglishTranslation = "LYD",
                    CodeFrenchTranslation = "LYD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 84,
                        Code = "MOP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Macau Pataca",
                    NameEnglishTranslation = "Macau Pataca",
                    NameFrenchTranslation = "Macau Pataca",

                    CodeArabicTranslation = "MOP",
                    CodeEnglishTranslation = "MOP",
                    CodeFrenchTranslation = "MOP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 85,
                        Code = "MKD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Macedonian Denar",
                    NameEnglishTranslation = "Macedonian Denar",
                    NameFrenchTranslation = "Macedonian Denar",

                    CodeArabicTranslation = "MKD",
                    CodeEnglishTranslation = "MKD",
                    CodeFrenchTranslation = "MKD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 86,
                        Code = "MGA",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Malagasy Ariary",
                    NameEnglishTranslation = "Malagasy Ariary",
                    NameFrenchTranslation = "Malagasy Ariary",

                    CodeArabicTranslation = "MGA",
                    CodeEnglishTranslation = "MGA",
                    CodeFrenchTranslation = "MGA",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 87,
                        Code = "MWK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Malawi Kwacha",
                    NameEnglishTranslation = "Malawi Kwacha",
                    NameFrenchTranslation = "Malawi Kwacha",

                    CodeArabicTranslation = "MWK",
                    CodeEnglishTranslation = "MWK",
                    CodeFrenchTranslation = "MWK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 88,
                        Code = "MYR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Malaysian Ringgit",
                    NameEnglishTranslation = "Malaysian Ringgit",
                    NameFrenchTranslation = "Malaysian Ringgit",

                    CodeArabicTranslation = "MYR",
                    CodeEnglishTranslation = "MYR",
                    CodeFrenchTranslation = "MYR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 89,
                        Code = "MVR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Maldives Rufiyaa",
                    NameEnglishTranslation = "Maldives Rufiyaa",
                    NameFrenchTranslation = "Maldives Rufiyaa",

                    CodeArabicTranslation = "MVR",
                    CodeEnglishTranslation = "MVR",
                    CodeFrenchTranslation = "MVR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 90,
                        Code = "MRO",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mauritania Ouguiya",
                    NameEnglishTranslation = "Mauritania Ouguiya",
                    NameFrenchTranslation = "Mauritania Ouguiya",

                    CodeArabicTranslation = "MRO",
                    CodeEnglishTranslation = "MRO",
                    CodeFrenchTranslation = "MRO",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 91,
                        Code = "MUR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mauritius Rupee",
                    NameEnglishTranslation = "Mauritius Rupee",
                    NameFrenchTranslation = "Mauritius Rupee",

                    CodeArabicTranslation = "MUR",
                    CodeEnglishTranslation = "MUR",
                    CodeFrenchTranslation = "MUR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 92,
                        Code = "MXN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mexican Peso",
                    NameEnglishTranslation = "Mexican Peso",
                    NameFrenchTranslation = "Mexican Peso",

                    CodeArabicTranslation = "MXN",
                    CodeEnglishTranslation = "MXN",
                    CodeFrenchTranslation = "MXN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 93,
                        Code = "MXV",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mexican Unidad de Inversion (UDI)",
                    NameEnglishTranslation = "Mexican Unidad de Inversion (UDI)",
                    NameFrenchTranslation = "Mexican Unidad de Inversion (UDI)",

                    CodeArabicTranslation = "MXV",
                    CodeEnglishTranslation = "MXV",
                    CodeFrenchTranslation = "MXV",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 94,
                        Code = "MDL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Moldovan Leu",
                    NameEnglishTranslation = "Moldovan Leu",
                    NameFrenchTranslation = "Moldovan Leu",

                    CodeArabicTranslation = "MDL",
                    CodeEnglishTranslation = "MDL",
                    CodeFrenchTranslation = "MDL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 95,
                        Code = "MNT",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mongolian Tugrik",
                    NameEnglishTranslation = "Mongolian Tugrik",
                    NameFrenchTranslation = "Mongolian Tugrik",

                    CodeArabicTranslation = "MNT",
                    CodeEnglishTranslation = "MNT",
                    CodeFrenchTranslation = "MNT",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 96,
                        Code = "MAD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Moroccan Dirham",
                    NameEnglishTranslation = "Moroccan Dirham",
                    NameFrenchTranslation = "Moroccan Dirham",

                    CodeArabicTranslation = "MAD",
                    CodeEnglishTranslation = "MAD",
                    CodeFrenchTranslation = "MAD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 97,
                        Code = "MZN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Mozambique Metical",
                    NameEnglishTranslation = "Mozambique Metical",
                    NameFrenchTranslation = "Mozambique Metical",

                    CodeArabicTranslation = "MZN",
                    CodeEnglishTranslation = "MZN",
                    CodeFrenchTranslation = "MZN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 98,
                        Code = "MMK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Myanmar Kyat",
                    NameEnglishTranslation = "Myanmar Kyat",
                    NameFrenchTranslation = "Myanmar Kyat",

                    CodeArabicTranslation = "MMK",
                    CodeEnglishTranslation = "MMK",
                    CodeFrenchTranslation = "MMK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 99,
                        Code = "NAD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Namibia Dollar",
                    NameEnglishTranslation = "Namibia Dollar",
                    NameFrenchTranslation = "Namibia Dollar",

                    CodeArabicTranslation = "NAD",
                    CodeEnglishTranslation = "NAD",
                    CodeFrenchTranslation = "NAD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 100,
                        Code = "NPR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Nepalese Rupee",
                    NameEnglishTranslation = "Nepalese Rupee",
                    NameFrenchTranslation = "Nepalese Rupee",

                    CodeArabicTranslation = "NPR",
                    CodeEnglishTranslation = "NPR",
                    CodeFrenchTranslation = "NPR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 101,
                        Code = "ANG",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Netherlands Antillean Guilder",
                    NameEnglishTranslation = "Netherlands Antillean Guilder",
                    NameFrenchTranslation = "Netherlands Antillean Guilder",

                    CodeArabicTranslation = "ANG",
                    CodeEnglishTranslation = "ANG",
                    CodeFrenchTranslation = "ANG",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 102,
                        Code = "ILS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "New Israeli Sheqel",
                    NameEnglishTranslation = "New Israeli Sheqel",
                    NameFrenchTranslation = "New Israeli Sheqel",

                    CodeArabicTranslation = "ILS",
                    CodeEnglishTranslation = "ILS",
                    CodeFrenchTranslation = "ILS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 103,
                        Code = "TWD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "New Taiwan Dollar",
                    NameEnglishTranslation = "New Taiwan Dollar",
                    NameFrenchTranslation = "New Taiwan Dollar",

                    CodeArabicTranslation = "TWD",
                    CodeEnglishTranslation = "TWD",
                    CodeFrenchTranslation = "TWD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 104,
                        Code = "NZD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "New Zealand Dollar",
                    NameEnglishTranslation = "New Zealand Dollar",
                    NameFrenchTranslation = "New Zealand Dollar",

                    CodeArabicTranslation = "NZD",
                    CodeEnglishTranslation = "NZD",
                    CodeFrenchTranslation = "NZD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 105,
                        Code = "NIO",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Nicaraguan Cordoba Oro",
                    NameEnglishTranslation = "Nicaraguan Cordoba Oro",
                    NameFrenchTranslation = "Nicaraguan Cordoba Oro",

                    CodeArabicTranslation = "NIO",
                    CodeEnglishTranslation = "NIO",
                    CodeFrenchTranslation = "NIO",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 106,
                        Code = "NGN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Nigerian Naira",
                    NameEnglishTranslation = "Nigerian Naira",
                    NameFrenchTranslation = "Nigerian Naira",

                    CodeArabicTranslation = "NGN",
                    CodeEnglishTranslation = "NGN",
                    CodeFrenchTranslation = "NGN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 107,
                        Code = "KPW",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "North Korean Won",
                    NameEnglishTranslation = "North Korean Won",
                    NameFrenchTranslation = "North Korean Won",

                    CodeArabicTranslation = "KPW",
                    CodeEnglishTranslation = "KPW",
                    CodeFrenchTranslation = "KPW",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 108,
                        Code = "NOK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Norwegian Krone",
                    NameEnglishTranslation = "Norwegian Krone",
                    NameFrenchTranslation = "Norwegian Krone",

                    CodeArabicTranslation = "NOK",
                    CodeEnglishTranslation = "NOK",
                    CodeFrenchTranslation = "NOK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 109,
                        Code = "PKR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Pakistan Rupee",
                    NameEnglishTranslation = "Pakistan Rupee",
                    NameFrenchTranslation = "Pakistan Rupee",

                    CodeArabicTranslation = "PKR",
                    CodeEnglishTranslation = "PKR",
                    CodeFrenchTranslation = "PKR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 110,
                        Code = "PAB",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Panama Balboa",
                    NameEnglishTranslation = "Panama Balboa",
                    NameFrenchTranslation = "Panama Balboa",

                    CodeArabicTranslation = "PAB",
                    CodeEnglishTranslation = "PAB",
                    CodeFrenchTranslation = "PAB",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 111,
                        Code = "PGK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Papua New Guinea Kina",
                    NameEnglishTranslation = "Papua New Guinea Kina",
                    NameFrenchTranslation = "Papua New Guinea Kina",

                    CodeArabicTranslation = "PGK",
                    CodeEnglishTranslation = "PGK",
                    CodeFrenchTranslation = "PGK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 112,
                        Code = "PYG",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Paraguayan Guarani",
                    NameEnglishTranslation = "Paraguayan Guarani",
                    NameFrenchTranslation = "Paraguayan Guarani",

                    CodeArabicTranslation = "PYG",
                    CodeEnglishTranslation = "PYG",
                    CodeFrenchTranslation = "PYG",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 113,
                        Code = "PEN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Peruvian Nuevo Sol",
                    NameEnglishTranslation = "Peruvian Nuevo Sol",
                    NameFrenchTranslation = "Peruvian Nuevo Sol",

                    CodeArabicTranslation = "PEN",
                    CodeEnglishTranslation = "PEN",
                    CodeFrenchTranslation = "PEN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 114,
                        Code = "CUC",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Peso Convertible",
                    NameEnglishTranslation = "Peso Convertible",
                    NameFrenchTranslation = "Peso Convertible",

                    CodeArabicTranslation = "CUC",
                    CodeEnglishTranslation = "CUC",
                    CodeFrenchTranslation = "CUC",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 115,
                        Code = "UYU",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Peso Uruguayo",
                    NameEnglishTranslation = "Peso Uruguayo",
                    NameFrenchTranslation = "Peso Uruguayo",

                    CodeArabicTranslation = "UYU",
                    CodeEnglishTranslation = "UYU",
                    CodeFrenchTranslation = "UYU",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 116,
                        Code = "PHP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Philippine Peso",
                    NameEnglishTranslation = "Philippine Peso",
                    NameFrenchTranslation = "Philippine Peso",

                    CodeArabicTranslation = "PHP",
                    CodeEnglishTranslation = "PHP",
                    CodeFrenchTranslation = "PHP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 117,
                        Code = "PLN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Polish Zloty",
                    NameEnglishTranslation = "Polish Zloty",
                    NameFrenchTranslation = "Polish Zloty",

                    CodeArabicTranslation = "PLN",
                    CodeEnglishTranslation = "PLN",
                    CodeFrenchTranslation = "PLN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 118,
                        Code = "GBP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Pound Sterling",
                    NameEnglishTranslation = "Pound Sterling",
                    NameFrenchTranslation = "Pound Sterling",

                    CodeArabicTranslation = "GBP",
                    CodeEnglishTranslation = "GBP",
                    CodeFrenchTranslation = "GBP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 119,
                        Code = "QAR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Qatari Rial",
                    NameEnglishTranslation = "Qatari Rial",
                    NameFrenchTranslation = "Qatari Rial",

                    CodeArabicTranslation = "QAR",
                    CodeEnglishTranslation = "QAR",
                    CodeFrenchTranslation = "QAR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 120,
                        Code = "OMR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Rial Omani",
                    NameEnglishTranslation = "Rial Omani",
                    NameFrenchTranslation = "Rial Omani",

                    CodeArabicTranslation = "OMR",
                    CodeEnglishTranslation = "OMR",
                    CodeFrenchTranslation = "OMR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 121,
                        Code = "RON",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Romanian Leu",
                    NameEnglishTranslation = "Romanian Leu",
                    NameFrenchTranslation = "Romanian Leu",

                    CodeArabicTranslation = "RON",
                    CodeEnglishTranslation = "RON",
                    CodeFrenchTranslation = "RON",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 122,
                        Code = "RUB",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Russian Ruble",
                    NameEnglishTranslation = "Russian Ruble",
                    NameFrenchTranslation = "Russian Ruble",

                    CodeArabicTranslation = "RUB",
                    CodeEnglishTranslation = "RUB",
                    CodeFrenchTranslation = "RUB",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 123,
                        Code = "RWF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Rwanda Franc",
                    NameEnglishTranslation = "Rwanda Franc",
                    NameFrenchTranslation = "Rwanda Franc",

                    CodeArabicTranslation = "RWF",
                    CodeEnglishTranslation = "RWF",
                    CodeFrenchTranslation = "RWF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 124,
                        Code = "SHP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Saint Helena Pound",
                    NameEnglishTranslation = "Saint Helena Pound",
                    NameFrenchTranslation = "Saint Helena Pound",

                    CodeArabicTranslation = "SHP",
                    CodeEnglishTranslation = "SHP",
                    CodeFrenchTranslation = "SHP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 125,
                        Code = "WST",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Samoa Tala",
                    NameEnglishTranslation = "Samoa Tala",
                    NameFrenchTranslation = "Samoa Tala",

                    CodeArabicTranslation = "WST",
                    CodeEnglishTranslation = "WST",
                    CodeFrenchTranslation = "WST",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 126,
                        Code = "STD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "São Tome and Principe Dobra",
                    NameEnglishTranslation = "São Tome and Principe Dobra",
                    NameFrenchTranslation = "São Tome and Principe Dobra",

                    CodeArabicTranslation = "STD",
                    CodeEnglishTranslation = "STD",
                    CodeFrenchTranslation = "STD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 127,
                        Code = "SAR",
                        IsActive = true,
                        IsNameFeminine = true,
                        IsUnitNameFeminine = true,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "الريال السعودى",
                    NameEnglishTranslation = "Saudi Riyal",
                    NameFrenchTranslation = "Riyal saoudien",

                    CodeArabicTranslation = "ريال",
                    CodeEnglishTranslation = "SAR",
                    CodeFrenchTranslation = "SAR",

                    UnitNameArabicTranslation = "هلله",
                    UnitNameEnglishTranslation = "Halala",
                    UnitNameFrenchTranslation = "Halala",

                    PluralNameArabicTranslation = "ريال",
                    PluralNameEnglishTranslation = "Riyals",
                    PluralNameFrenchTranslation = "Riyals",

                    PluralUnitNameArabicTranslation = "هلله",
                    PluralUnitNameEnglishTranslation = "Halalas",
                    PluralUnitNameFrenchTranslation = "Halalas",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 128,
                        Code = "RSD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Serbian Dinar",
                    NameEnglishTranslation = "Serbian Dinar",
                    NameFrenchTranslation = "Serbian Dinar",

                    CodeArabicTranslation = "RSD",
                    CodeEnglishTranslation = "RSD",
                    CodeFrenchTranslation = "RSD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 129,
                        Code = "SCR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Seychelles Rupee",
                    NameEnglishTranslation = "Seychelles Rupee",
                    NameFrenchTranslation = "Seychelles Rupee",

                    CodeArabicTranslation = "SCR",
                    CodeEnglishTranslation = "SCR",
                    CodeFrenchTranslation = "SCR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 130,
                        Code = "SLL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Sierra Leonean Leone",
                    NameEnglishTranslation = "Sierra Leonean Leone",
                    NameFrenchTranslation = "Sierra Leonean Leone",

                    CodeArabicTranslation = "SLL",
                    CodeEnglishTranslation = "SLL",
                    CodeFrenchTranslation = "SLL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 131,
                        Code = "SGD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Singapore Dollar",
                    NameEnglishTranslation = "Singapore Dollar",
                    NameFrenchTranslation = "Singapore Dollar",

                    CodeArabicTranslation = "SGD",
                    CodeEnglishTranslation = "SGD",
                    CodeFrenchTranslation = "SGD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 132,
                        Code = "SBD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Solomon Islands Dollar",
                    NameEnglishTranslation = "Solomon Islands Dollar",
                    NameFrenchTranslation = "Solomon Islands Dollar",

                    CodeArabicTranslation = "SBD",
                    CodeEnglishTranslation = "SBD",
                    CodeFrenchTranslation = "SBD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 133,
                        Code = "SOS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Somali Shilling",
                    NameEnglishTranslation = "Somali Shilling",
                    NameFrenchTranslation = "Somali Shilling",

                    CodeArabicTranslation = "SOS",
                    CodeEnglishTranslation = "SOS",
                    CodeFrenchTranslation = "SOS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 134,
                        Code = "ZAR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "South African Rand",
                    NameEnglishTranslation = "South African Rand",
                    NameFrenchTranslation = "South African Rand",

                    CodeArabicTranslation = "ZAR",
                    CodeEnglishTranslation = "ZAR",
                    CodeFrenchTranslation = "ZAR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 135,
                        Code = "SSP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "South Sudanese Pound",
                    NameEnglishTranslation = "South Sudanese Pound",
                    NameFrenchTranslation = "South Sudanese Pound",

                    CodeArabicTranslation = "SSP",
                    CodeEnglishTranslation = "SSP",
                    CodeFrenchTranslation = "SSP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 136,
                        Code = "LKR",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Sri Lanka Rupee",
                    NameEnglishTranslation = "Sri Lanka Rupee",
                    NameFrenchTranslation = "Sri Lanka Rupee",

                    CodeArabicTranslation = "LKR",
                    CodeEnglishTranslation = "LKR",
                    CodeFrenchTranslation = "LKR",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 137,
                        Code = "SDG",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Sudanese Pound",
                    NameEnglishTranslation = "Sudanese Pound",
                    NameFrenchTranslation = "Sudanese Pound",

                    CodeArabicTranslation = "SDG",
                    CodeEnglishTranslation = "SDG",
                    CodeFrenchTranslation = "SDG",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 138,
                        Code = "SRD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Surinam Dollar",
                    NameEnglishTranslation = "Surinam Dollar",
                    NameFrenchTranslation = "Surinam Dollar",

                    CodeArabicTranslation = "SRD",
                    CodeEnglishTranslation = "SRD",
                    CodeFrenchTranslation = "SRD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 139,
                        Code = "SZL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Swaziland Lilangeni",
                    NameEnglishTranslation = "Swaziland Lilangeni",
                    NameFrenchTranslation = "Swaziland Lilangeni",

                    CodeArabicTranslation = "SZL",
                    CodeEnglishTranslation = "SZL",
                    CodeFrenchTranslation = "SZL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 140,
                        Code = "SEK",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Swedish Krona",
                    NameEnglishTranslation = "Swedish Krona",
                    NameFrenchTranslation = "Swedish Krona",

                    CodeArabicTranslation = "SEK",
                    CodeEnglishTranslation = "SEK",
                    CodeFrenchTranslation = "SEK",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 141,
                        Code = "CHF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Swiss Franc",
                    NameEnglishTranslation = "Swiss Franc",
                    NameFrenchTranslation = "Swiss Franc",

                    CodeArabicTranslation = "CHF",
                    CodeEnglishTranslation = "CHF",
                    CodeFrenchTranslation = "CHF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 142,
                        Code = "SYP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Syrian Pound",
                    NameEnglishTranslation = "Syrian Pound",
                    NameFrenchTranslation = "Syrian Pound",

                    CodeArabicTranslation = "SYP",
                    CodeEnglishTranslation = "SYP",
                    CodeFrenchTranslation = "SYP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 143,
                        Code = "TJS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Tajikistani Somoni",
                    NameEnglishTranslation = "Tajikistani Somoni",
                    NameFrenchTranslation = "Tajikistani Somoni",

                    CodeArabicTranslation = "TJS",
                    CodeEnglishTranslation = "TJS",
                    CodeFrenchTranslation = "TJS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 144,
                        Code = "TZS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Tanzanian Shilling",
                    NameEnglishTranslation = "Tanzanian Shilling",
                    NameFrenchTranslation = "Tanzanian Shilling",

                    CodeArabicTranslation = "TZS",
                    CodeEnglishTranslation = "TZS",
                    CodeFrenchTranslation = "TZS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 145,
                        Code = "THB",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Thai Baht",
                    NameEnglishTranslation = "Thai Baht",
                    NameFrenchTranslation = "Thai Baht",

                    CodeArabicTranslation = "THB",
                    CodeEnglishTranslation = "THB",
                    CodeFrenchTranslation = "THB",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 146,
                        Code = "TOP",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Tonga Pa'anga",
                    NameEnglishTranslation = "Tonga Pa'anga",
                    NameFrenchTranslation = "Tonga Pa'anga",

                    CodeArabicTranslation = "TOP",
                    CodeEnglishTranslation = "TOP",
                    CodeFrenchTranslation = "TOP",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 147,
                        Code = "TTD",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Trinidad and Tobago Dollar",
                    NameEnglishTranslation = "Trinidad and Tobago Dollar",
                    NameFrenchTranslation = "Trinidad and Tobago Dollar",

                    CodeArabicTranslation = "TTD",
                    CodeEnglishTranslation = "TTD",
                    CodeFrenchTranslation = "TTD",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 148,
                        Code = "TND",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 3
                    },
                    NameArabicTranslation = "Tunisian Dinar",
                    NameEnglishTranslation = "Tunisian Dinar",
                    NameFrenchTranslation = "Tunisian Dinar",

                    CodeArabicTranslation = "TND",
                    CodeEnglishTranslation = "TND",
                    CodeFrenchTranslation = "TND",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 149,
                        Code = "TRY",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Turkish Lira",
                    NameEnglishTranslation = "Turkish Lira",
                    NameFrenchTranslation = "Turkish Lira",

                    CodeArabicTranslation = "TRY",
                    CodeEnglishTranslation = "TRY",
                    CodeFrenchTranslation = "TRY",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 150,
                        Code = "TMT",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Turkmenistan New Manat",
                    NameEnglishTranslation = "Turkmenistan New Manat",
                    NameFrenchTranslation = "Turkmenistan New Manat",

                    CodeArabicTranslation = "TMT",
                    CodeEnglishTranslation = "TMT",
                    CodeFrenchTranslation = "TMT",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 151,
                        Code = "AED",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = true,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "درهم الامارات العربية المتحدة",
                    NameEnglishTranslation = "UAE Dirham",
                    NameFrenchTranslation = "Emirats Arabes Unis dirham",

                    CodeArabicTranslation = "درهم",
                    CodeEnglishTranslation = "AED",
                    CodeFrenchTranslation = "AED",

                    UnitNameArabicTranslation = "فلس",
                    UnitNameEnglishTranslation = "Fils",
                    UnitNameFrenchTranslation = "Fils",

                    PluralNameArabicTranslation = "دراهم",
                    PluralNameEnglishTranslation = "Derhams",
                    PluralNameFrenchTranslation = "Derhams",

                    PluralUnitNameArabicTranslation = "فلس",
                    PluralUnitNameEnglishTranslation = "Filses",
                    PluralUnitNameFrenchTranslation = "Filses",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 152,
                        Code = "UGX",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Uganda Shilling",
                    NameEnglishTranslation = "Uganda Shilling",
                    NameFrenchTranslation = "Uganda Shilling",

                    CodeArabicTranslation = "UGX",
                    CodeEnglishTranslation = "UGX",
                    CodeFrenchTranslation = "UGX",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 153,
                        Code = "UAH",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Ukraine Hryvnia",
                    NameEnglishTranslation = "Ukraine Hryvnia",
                    NameFrenchTranslation = "Ukraine Hryvnia",

                    CodeArabicTranslation = "UAH",
                    CodeEnglishTranslation = "UAH",
                    CodeFrenchTranslation = "UAH",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 154,
                        Code = "UYI",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Uruguay Peso en Unidades Indexadas (URUIURUI)",
                    NameEnglishTranslation = "Uruguay Peso en Unidades Indexadas (URUIURUI)",
                    NameFrenchTranslation = "Uruguay Peso en Unidades Indexadas (URUIURUI)",

                    CodeArabicTranslation = "UYI",
                    CodeEnglishTranslation = "UYI",
                    CodeFrenchTranslation = "UYI",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 155,
                        Code = "USD",
                        IsActive = true,
                        IsNameFeminine = true,
                        IsUnitNameFeminine = true,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "دولار الامريكى",
                    NameEnglishTranslation = "US Dollar",
                    NameFrenchTranslation = "Le dollar américain",

                    CodeArabicTranslation = "دولار",
                    CodeEnglishTranslation = "USD",
                    CodeFrenchTranslation = "USD",

                    UnitNameArabicTranslation = "سنت",
                    UnitNameEnglishTranslation = "Cent",
                    UnitNameFrenchTranslation = "Cent",

                    PluralNameArabicTranslation = "دولارات",
                    PluralNameEnglishTranslation = "Dollars",
                    PluralNameFrenchTranslation = "Dollars",

                    PluralUnitNameArabicTranslation = "سنتات",
                    PluralUnitNameEnglishTranslation = "Cents",
                    PluralUnitNameFrenchTranslation = "Cents",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 156,
                        Code = "USN",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "US Dollar (Next day)",
                    NameEnglishTranslation = "US Dollar (Next day)",
                    NameFrenchTranslation = "US Dollar (Next day)",

                    CodeArabicTranslation = "USN",
                    CodeEnglishTranslation = "USN",
                    CodeFrenchTranslation = "USN",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 157,
                        Code = "UZS",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Uzbekistan Sum",
                    NameEnglishTranslation = "Uzbekistan Sum",
                    NameFrenchTranslation = "Uzbekistan Sum",

                    CodeArabicTranslation = "UZS",
                    CodeEnglishTranslation = "UZS",
                    CodeFrenchTranslation = "UZS",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 158,
                        Code = "VUV",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Vanuatu Vatu",
                    NameEnglishTranslation = "Vanuatu Vatu",
                    NameFrenchTranslation = "Vanuatu Vatu",

                    CodeArabicTranslation = "VUV",
                    CodeEnglishTranslation = "VUV",
                    CodeFrenchTranslation = "VUV",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 159,
                        Code = "VEF",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Venezuelan Bolivar",
                    NameEnglishTranslation = "Venezuelan Bolivar",
                    NameFrenchTranslation = "Venezuelan Bolivar",

                    CodeArabicTranslation = "VEF",
                    CodeEnglishTranslation = "VEF",
                    CodeFrenchTranslation = "VEF",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 160,
                        Code = "VND",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 0
                    },
                    NameArabicTranslation = "Vietnamese Dong",
                    NameEnglishTranslation = "Vietnamese Dong",
                    NameFrenchTranslation = "Vietnamese Dong",

                    CodeArabicTranslation = "VND",
                    CodeEnglishTranslation = "VND",
                    CodeFrenchTranslation = "VND",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 161,
                        Code = "CHE",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "WIR Euro",
                    NameEnglishTranslation = "WIR Euro",
                    NameFrenchTranslation = "WIR Euro",

                    CodeArabicTranslation = "CHE",
                    CodeEnglishTranslation = "CHE",
                    CodeFrenchTranslation = "CHE",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 162,
                        Code = "CHW",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "WIR Franc",
                    NameEnglishTranslation = "WIR Franc",
                    NameFrenchTranslation = "WIR Franc",

                    CodeArabicTranslation = "CHW",
                    CodeEnglishTranslation = "CHW",
                    CodeFrenchTranslation = "CHW",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 163,
                        Code = "YER",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Yemeni Rial",
                    NameEnglishTranslation = "Yemeni Rial",
                    NameFrenchTranslation = "Yemeni Rial",

                    CodeArabicTranslation = "YER",
                    CodeEnglishTranslation = "YER",
                    CodeFrenchTranslation = "YER",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 164,
                        Code = "ZMW",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Zambian Kwacha",
                    NameEnglishTranslation = "Zambian Kwacha",
                    NameFrenchTranslation = "Zambian Kwacha",

                    CodeArabicTranslation = "ZMW",
                    CodeEnglishTranslation = "ZMW",
                    CodeFrenchTranslation = "ZMW",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                },
                new CurrencyLocalizable
                {
                    CurrencyObj = new Currency
                    {
                        Id = 165,
                        Code = "ZWL",
                        IsActive = true,
                        IsNameFeminine = false,
                        IsUnitNameFeminine = false,
                        UnitPrecision = 2
                    },
                    NameArabicTranslation = "Zimbabwe Dollar",
                    NameEnglishTranslation = "Zimbabwe Dollar",
                    NameFrenchTranslation = "Zimbabwe Dollar",

                    CodeArabicTranslation = "ZWL",
                    CodeEnglishTranslation = "ZWL",
                    CodeFrenchTranslation = "ZWL",

                    UnitNameArabicTranslation = "",
                    UnitNameEnglishTranslation = "",
                    UnitNameFrenchTranslation = "",

                    PluralNameArabicTranslation = "",
                    PluralNameEnglishTranslation = "",
                    PluralNameFrenchTranslation = "",

                    PluralUnitNameArabicTranslation = "",
                    PluralUnitNameEnglishTranslation = "",
                    PluralUnitNameFrenchTranslation = "",
                }
            };

        private class CurrencyLocalizable
        {
            public Currency CurrencyObj { get; set; }

            public string NameEnglishTranslation { get; set; }

            public string NameArabicTranslation { get; set; }

            public string NameFrenchTranslation { get; set; }

            public string CodeEnglishTranslation { get; set; }

            public string CodeArabicTranslation { get; set; }

            public string CodeFrenchTranslation { get; set; }

            public string UnitNameEnglishTranslation { get; set; }

            public string UnitNameArabicTranslation { get; set; }

            public string UnitNameFrenchTranslation { get; set; }

            public string PluralNameEnglishTranslation { get; set; }

            public string PluralNameArabicTranslation { get; set; }

            public string PluralNameFrenchTranslation { get; set; }

            public string PluralUnitNameEnglishTranslation { get; set; }

            public string PluralUnitNameArabicTranslation { get; set; }

            public string PluralUnitNameFrenchTranslation { get; set; }
        }
    }
}
