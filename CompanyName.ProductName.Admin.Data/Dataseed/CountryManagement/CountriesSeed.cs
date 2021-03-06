namespace CompanyName.ProductName.Admin.Data.Dataseed.CountryManagement
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement;
    using CompanyName.ProductName.Admin.Data.Entities;
    using CompanyName.ProductName.Admin.Core;

    public class CountriesSeed : SeedBase<Country>
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

        private void AddOrUpdate(CountryLocalizable[] entities)
        {
            foreach (var entity in entities)
            {
                var element = EnsureEntity(entity);

                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.English, entity.NameEnglishTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.Arabic, entity.NameArabicTranslation);
                _Translator.Translate(element, l => l.NameTranslation, SupportedLanguages.French, entity.NameFrenchTranslation);
            }
        }

        private Country EnsureEntity(CountryLocalizable country)
        {
            var element = _DbContext.Countries.AsNoTracking().FirstOrDefault(p => p.Id == country.CountryObj.Id);

            if (element == null)
            {
                element = new Country
                {
                    Id = country.CountryObj.Id,
                    CurrencyId = country.CountryObj.CurrencyId,
                    ISO2 = country.CountryObj.ISO2,
                    ISO3 = country.CountryObj.ISO3,
                    PhoneCode = country.CountryObj.PhoneCode
                };

                _DbContext.Countries.Add(element);
            }
            else
            {
                element.CurrencyId = country.CountryObj.CurrencyId;
                element.ISO2 = country.CountryObj.ISO2;
                element.ISO3 = country.CountryObj.ISO3;
                element.PhoneCode = country.CountryObj.PhoneCode;
            }

            _Translator.Translate(element, e => e.NameTranslation, country.NameEnglishTranslation);

            return element;
        }

        private CountryLocalizable[] GetAll() => new CountryLocalizable[]
            {
                                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 1,
                        ISO2 = "AF",
                        ISO3 = "AFG",
                        CurrencyId = 1,
                        PhoneCode = "+93"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Afghanistan",
                    NameFrenchTranslation = "Afghanistan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 2,
                        ISO2 = "AL",
                        ISO3 = "ALB",
                        CurrencyId = 2,
                        PhoneCode = "+355"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Albania",
                    NameFrenchTranslation = "Albanie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 3,
                        ISO2 = "DZ",
                        ISO3 = "DZA",
                        CurrencyId = 3,
                        PhoneCode = "+213"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Algeria",
                    NameFrenchTranslation = "Alg??rie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 4,
                        ISO2 = "AD",
                        ISO3 = "AND",
                        CurrencyId = 52,
                        PhoneCode = "+376"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Andorra",
                    NameFrenchTranslation = "Andorre"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 5,
                        ISO2 = "AO",
                        ISO3 = "AGO",
                        CurrencyId = 4,
                        PhoneCode = "+244"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Angola",
                    NameFrenchTranslation = "Angola"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 6,
                        ISO2 = "AI",
                        ISO3 = "AIA",
                        CurrencyId = 47,
                        PhoneCode = "+1264"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Anguilla",
                    NameFrenchTranslation = "Anguilla"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 7,
                        ISO2 = "AG",
                        ISO3 = "ATG",
                        CurrencyId = 47,
                        PhoneCode = "+1268"
                    },
                    NameArabicTranslation = "?????????????? ??????????????",
                    NameEnglishTranslation = "Antigua and Barbuda",
                    NameFrenchTranslation = "Antigua-et-Barbuda"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 8,
                        ISO2 = "AR",
                        ISO3 = "ARG",
                        CurrencyId = 5,
                        PhoneCode = "+54"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Argentina",
                    NameFrenchTranslation = "Argentine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 9,
                        ISO2 = "AM",
                        ISO3 = "ARM",
                        CurrencyId = 6,
                        PhoneCode = "+374"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Armenia",
                    NameFrenchTranslation = "Arm??nie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 10,
                        ISO2 = "AW",
                        ISO3 = "ABW",
                        CurrencyId = 7,
                        PhoneCode = "+297"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Aruba",
                    NameFrenchTranslation = "Aruba"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 11,
                        ISO2 = "AU",
                        ISO3 = "AUS",
                        CurrencyId = 8,
                        PhoneCode = "+61"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Australia",
                    NameFrenchTranslation = "Australie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 12,
                        ISO2 = "AT",
                        ISO3 = "AUT",
                        CurrencyId = 52,
                        PhoneCode = "+43"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Austria",
                    NameFrenchTranslation = "L&#39;Autriche"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 13,
                        ISO2 = "AZ",
                        ISO3 = "AZE",
                        CurrencyId = 9,
                        PhoneCode = "+994"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Azerbaijan",
                    NameFrenchTranslation = "Azerba??djan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 14,
                        ISO2 = "BS",
                        ISO3 = "BHS",
                        CurrencyId = 10,
                        PhoneCode = "+1242"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Bahamas",
                    NameFrenchTranslation = "Bahamas"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 15,
                        ISO2 = "BH",
                        ISO3 = "BHR",
                        CurrencyId = 11,
                        PhoneCode = "+973"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Bahrain",
                    NameFrenchTranslation = "Bahre??n"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 16,
                        ISO2 = "BD",
                        ISO3 = "BGD",
                        CurrencyId = 12,
                        PhoneCode = "+880"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Bangladesh",
                    NameFrenchTranslation = "Bangladesh"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 17,
                        ISO2 = "BB",
                        ISO3 = "BRB",
                        CurrencyId = 13,
                        PhoneCode = "+1246"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Barbados",
                    NameFrenchTranslation = "Barbade"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 18,
                        ISO2 = "BY",
                        ISO3 = "BLR",
                        CurrencyId = 14,
                        PhoneCode = "+375"
                    },
                    NameArabicTranslation = "?????????? ??????????????",
                    NameEnglishTranslation = "Belarus",
                    NameFrenchTranslation = "B??larus"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 19,
                        ISO2 = "BE",
                        ISO3 = "BEL",
                        CurrencyId = 52,
                        PhoneCode = "+32"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Belgium",
                    NameFrenchTranslation = "Belgique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 20,
                        ISO2 = "BZ",
                        ISO3 = "BLZ",
                        CurrencyId = 15,
                        PhoneCode = "+501"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Belize",
                    NameFrenchTranslation = "Belize"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 21,
                        ISO2 = "BJ",
                        ISO3 = "BEN",
                        CurrencyId = 30,
                        PhoneCode = "+229"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Benin",
                    NameFrenchTranslation = "B??nin"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 22,
                        ISO2 = "BM",
                        ISO3 = "BMU",
                        CurrencyId = 16,
                        PhoneCode = "+1441"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Bermuda",
                    NameFrenchTranslation = "Bermudes"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 23,
                        ISO2 = "BT",
                        ISO3 = "BTN",
                        CurrencyId = 17,
                        PhoneCode = "+975"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Bhutan",
                    NameFrenchTranslation = "Bhoutan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 24,
                        ISO2 = "BO",
                        ISO3 = "BOL",
                        CurrencyId = 18,
                        PhoneCode = "+591"
                    },
                    NameArabicTranslation = "?????????????? ?? ??????????????",
                    NameEnglishTranslation = "Bolivia, Plurination",
                    NameFrenchTranslation = "Bolivie, Plurination"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 25,
                        ISO2 = "BA",
                        ISO3 = "BIH",
                        CurrencyId = 20,
                        PhoneCode = "+387"
                    },
                    NameArabicTranslation = "?????????????? ????????????????????",
                    NameEnglishTranslation = "Bosnia and Herzegovi",
                    NameFrenchTranslation = "Bosnie et Herz??govine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 26,
                        ISO2 = "BW",
                        ISO3 = "BWA",
                        CurrencyId = 21,
                        PhoneCode = "+267"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Botswana",
                    NameFrenchTranslation = "Botswana"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 27,
                        ISO2 = "BR",
                        ISO3 = "BRA",
                        CurrencyId = 22,
                        PhoneCode = "+55"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Brazil",
                    NameFrenchTranslation = "Br??sil"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 28,
                        ISO2 = "BN",
                        ISO3 = "BRN",
                        CurrencyId = 23,
                        PhoneCode = "+673"
                    },
                    NameArabicTranslation = "???????????? ?????? ????????????",
                    NameEnglishTranslation = "Brunei Darussalam",
                    NameFrenchTranslation = "Brun??i Darussalam"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 29,
                        ISO2 = "BG",
                        ISO3 = "BGR",
                        CurrencyId = 24,
                        PhoneCode = "+359"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Bulgaria",
                    NameFrenchTranslation = "Bulgarie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 30,
                        ISO2 = "BF",
                        ISO3 = "BFA",
                        CurrencyId = 30,
                        PhoneCode = "+226"
                    },
                    NameArabicTranslation = "?????????????? ????????",
                    NameEnglishTranslation = "Burkina Faso",
                    NameFrenchTranslation = "Burkina Faso"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 31,
                        ISO2 = "BI",
                        ISO3 = "BDI",
                        CurrencyId = 25,
                        PhoneCode = "+257"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Burundi",
                    NameFrenchTranslation = "Burundi"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 32,
                        ISO2 = "KH",
                        ISO3 = "KHM",
                        CurrencyId = 27,
                        PhoneCode = "+855"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Cambodia",
                    NameFrenchTranslation = "Cambodge"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 33,
                        ISO2 = "CM",
                        ISO3 = "CMR",
                        CurrencyId = 31,
                        PhoneCode = "+237"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Cameroon",
                    NameFrenchTranslation = "Cameroun"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 34,
                        ISO2 = "CA",
                        ISO3 = "CAN",
                        CurrencyId = 28,
                        PhoneCode = "+1"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Canada",
                    NameFrenchTranslation = "Canada"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 35,
                        ISO2 = "CV",
                        ISO3 = "CPV",
                        CurrencyId = 26,
                        PhoneCode = "+238"
                    },
                    NameArabicTranslation = "?????????? ????????????",
                    NameEnglishTranslation = "Cape Verde",
                    NameFrenchTranslation = "Cap-Vert"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 36,
                        ISO2 = "KY",
                        ISO3 = "CYM",
                        CurrencyId = 29,
                        PhoneCode = "+ 345"
                    },
                    NameArabicTranslation = "?????? ????????????",
                    NameEnglishTranslation = "Cayman Islands",
                    NameFrenchTranslation = "??les Ca??mans"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 37,
                        ISO2 = "CF",
                        ISO3 = "CAF",
                        CurrencyId = 31,
                        PhoneCode = "+236"
                    },
                    NameArabicTranslation = "?????????????? ?????????????? ????????????",
                    NameEnglishTranslation = "Central African Repu",
                    NameFrenchTranslation = "R??publique centrafricaine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 38,
                        ISO2 = "TD",
                        ISO3 = "TCD",
                        CurrencyId = 31,
                        PhoneCode = "+235"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Chad",
                    NameFrenchTranslation = "Chad"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 39,
                        ISO2 = "CL",
                        ISO3 = "CHL",
                        CurrencyId = 33,
                        PhoneCode = "+56"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Chile",
                    NameFrenchTranslation = "Chili"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 40,
                        ISO2 = "CN",
                        ISO3 = "CHN",
                        CurrencyId = 36,
                        PhoneCode = "+86"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "China",
                    NameFrenchTranslation = "Chine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 41,
                        ISO2 = "CX",
                        ISO3 = "CXR",
                        CurrencyId = 8,
                        PhoneCode = "+61"
                    },
                    NameArabicTranslation = "?????????? ??????????????????",
                    NameEnglishTranslation = "Christmas Island",
                    NameFrenchTranslation = "L&#39;??le de no??l"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 42,
                        ISO2 = "CC",
                        ISO3 = "CCK",
                        CurrencyId = 8,
                        PhoneCode = "+61"
                    },
                    NameArabicTranslation = "?????? ?????????? (????????????)",
                    NameEnglishTranslation = "Cocos (Keeling) Islands",
                    NameFrenchTranslation = "??les Cocos (Keeling)"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 43,
                        ISO2 = "CO",
                        ISO3 = "COL",
                        CurrencyId = 37,
                        PhoneCode = "+57"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Colombia",
                    NameFrenchTranslation = "La Colombie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 44,
                        ISO2 = "KM",
                        ISO3 = "COM",
                        CurrencyId = 38,
                        PhoneCode = "+269"
                    },
                    NameArabicTranslation = "?????? ??????????",
                    NameEnglishTranslation = "Comoros",
                    NameFrenchTranslation = "Comores"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 45,
                        ISO2 = "CG",
                        ISO3 = "COG",
                        CurrencyId = 31,
                        PhoneCode = "+242"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Congo",
                    NameFrenchTranslation = "Congo"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 46,
                        ISO2 = "CD",
                        ISO3 = "COD",
                        CurrencyId = 39,
                        PhoneCode = "+243"
                    },
                    NameArabicTranslation = "?????????????? ?? ????????????????????????",
                    NameEnglishTranslation = "Congo, The Democrati",
                    NameFrenchTranslation = "Congo, les d??mocrates"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 47,
                        ISO2 = "CK",
                        ISO3 = "COK",
                        CurrencyId = 104,
                        PhoneCode = "+682"
                    },
                    NameArabicTranslation = "?????? ??????",
                    NameEnglishTranslation = "Cook Islands",
                    NameFrenchTranslation = "les ??les Cook"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 48,
                        ISO2 = "CR",
                        ISO3 = "CRI",
                        CurrencyId = 40,
                        PhoneCode = "+506"
                    },
                    NameArabicTranslation = "?????????? ????????",
                    NameEnglishTranslation = "Costa Rica",
                    NameFrenchTranslation = "Costa Rica"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 49,
                        ISO2 = "CI",
                        ISO3 = "CIV",
                        CurrencyId = 30,
                        PhoneCode = "+225"
                    },
                    NameArabicTranslation = "???????? ??????????",
                    NameEnglishTranslation = "Cote d'Ivoire",
                    NameFrenchTranslation = "Cote d'Ivoire"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 50,
                        ISO2 = "HR",
                        ISO3 = "HRV",
                        CurrencyId = 41,
                        PhoneCode = "+385"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Croatia",
                    NameFrenchTranslation = "Croatie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 51,
                        ISO2 = "CU",
                        ISO3 = "CUB",
                        CurrencyId = 114,
                        PhoneCode = "+53"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Cuba",
                    NameFrenchTranslation = "Cuba"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 52,
                        ISO2 = "CY",
                        ISO3 = "CYP",
                        CurrencyId = 52,
                        PhoneCode = "+357"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Cyprus",
                    NameFrenchTranslation = "Chypre"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 53,
                        ISO2 = "CZ",
                        ISO3 = "CZE",
                        CurrencyId = 43,
                        PhoneCode = "+420"
                    },
                    NameArabicTranslation = "?????????????? ????????????",
                    NameEnglishTranslation = "Czech Republic",
                    NameFrenchTranslation = "R??publique Tch??que"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 54,
                        ISO2 = "DK",
                        ISO3 = "DNK",
                        CurrencyId = 44,
                        PhoneCode = "+45"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Denmark",
                    NameFrenchTranslation = "Danemark"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 55,
                        ISO2 = "DJ",
                        ISO3 = "DJI",
                        CurrencyId = 45,
                        PhoneCode = "+253"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Djibouti",
                    NameFrenchTranslation = "Djibouti"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 56,
                        ISO2 = "DM",
                        ISO3 = "DMA",
                        CurrencyId = 47,
                        PhoneCode = "+1767"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Dominica",
                    NameFrenchTranslation = "Dominique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 57,
                        ISO2 = "DO",
                        ISO3 = "DOM",
                        CurrencyId = 46,
                        PhoneCode = "+1849"
                    },
                    NameArabicTranslation = "?????????????? ????????????????????",
                    NameEnglishTranslation = "Dominican Republic",
                    NameFrenchTranslation = "R??publique Dominicaine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 58,
                        ISO2 = "EC",
                        ISO3 = "ECU",
                        CurrencyId = 155,
                        PhoneCode = "+593"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Ecuador",
                    NameFrenchTranslation = "Equateur"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 59,
                        ISO2 = "EG",
                        ISO3 = "EGY",
                        CurrencyId = 48,
                        PhoneCode = "+20"
                    },
                    NameArabicTranslation = "??????",
                    NameEnglishTranslation = "Egypt",
                    NameFrenchTranslation = "Egypte"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 60,
                        ISO2 = "SV",
                        ISO3 = "SLV",
                        CurrencyId = 155,
                        PhoneCode = "+503"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "El Salvador",
                    NameFrenchTranslation = "Le sauveur"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 61,
                        ISO2 = "GQ",
                        ISO3 = "GNQ",
                        CurrencyId = 31,
                        PhoneCode = "+240"
                    },
                    NameArabicTranslation = "?????????? ????????????????????",
                    NameEnglishTranslation = "Equatorial Guinea",
                    NameFrenchTranslation = "Guin??e ??quatoriale"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 62,
                        ISO2 = "ER",
                        ISO3 = "ERI",
                        CurrencyId = 50,
                        PhoneCode = "+291"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Eritrea",
                    NameFrenchTranslation = "??rythr??e"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 63,
                        ISO2 = "EE",
                        ISO3 = "EST",
                        CurrencyId = 52,
                        PhoneCode = "+372"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Estonia",
                    NameFrenchTranslation = "Estonie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 64,
                        ISO2 = "ET",
                        ISO3 = "ETH",
                        CurrencyId = 51,
                        PhoneCode = "+251"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Ethiopia",
                    NameFrenchTranslation = "Ethiopie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 65,
                        ISO2 = "FK",
                        ISO3 = "FLK",
                        CurrencyId = 53,
                        PhoneCode = "+500"
                    },
                    NameArabicTranslation = "?????? ?????????????? (????",
                    NameEnglishTranslation = "Falkland Islands (Ma",
                    NameFrenchTranslation = "??les Falkland (Ma"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 66,
                        ISO2 = "FO",
                        ISO3 = "FRO",
                        CurrencyId = 44,
                        PhoneCode = "+298"
                    },
                    NameArabicTranslation = "?????? ????????????",
                    NameEnglishTranslation = "Faroe Islands",
                    NameFrenchTranslation = "??les F??ro??"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 67,
                        ISO2 = "FJ",
                        ISO3 = "FJI",
                        CurrencyId = 54,
                        PhoneCode = "+679"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Fiji",
                    NameFrenchTranslation = "Fidji"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 68,
                        ISO2 = "FI",
                        ISO3 = "FIN",
                        CurrencyId = 52,
                        PhoneCode = "+358"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Finland",
                    NameFrenchTranslation = "Finlande"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 69,
                        ISO2 = "FR",
                        ISO3 = "FRA",
                        CurrencyId = 52,
                        PhoneCode = "+33"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "France",
                    NameFrenchTranslation = "France"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 70,
                        ISO2 = "GF",
                        ISO3 = "GUF",
                        CurrencyId = 52,
                        PhoneCode = "+594"
                    },
                    NameArabicTranslation = "?????????? ????????????????",
                    NameEnglishTranslation = "French Guiana",
                    NameFrenchTranslation = "Guin??e Fran??aise"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 71,
                        ISO2 = "PF",
                        ISO3 = "PYF",
                        CurrencyId = 32,
                        PhoneCode = "+689"
                    },
                    NameArabicTranslation = "?????????????????? ????????????????",
                    NameEnglishTranslation = "French Polynesia",
                    NameFrenchTranslation = "Polyn??sie fran??aise"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 72,
                        ISO2 = "GA",
                        ISO3 = "GAB",
                        CurrencyId = 31,
                        PhoneCode = "+241"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Gabon",
                    NameFrenchTranslation = "Gabon"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 73,
                        ISO2 = "GM",
                        ISO3 = "GMB",
                        CurrencyId = 55,
                        PhoneCode = "+220"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Gambia",
                    NameFrenchTranslation = "Gambie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 74,
                        ISO2 = "GE",
                        ISO3 = "GEO",
                        CurrencyId = 56,
                        PhoneCode = "+995"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Georgia",
                    NameFrenchTranslation = "G??orgie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 75,
                        ISO2 = "DE",
                        ISO3 = "DEU",
                        CurrencyId = 52,
                        PhoneCode = "+49"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Germany",
                    NameFrenchTranslation = "Allemagne"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 76,
                        ISO2 = "GH",
                        ISO3 = "GHA",
                        CurrencyId = 57,
                        PhoneCode = "+233"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Ghana",
                    NameFrenchTranslation = "Ghana"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 77,
                        ISO2 = "GI",
                        ISO3 = "GIB",
                        CurrencyId = 58,
                        PhoneCode = "+350"
                    },
                    NameArabicTranslation = "?????? ????????",
                    NameEnglishTranslation = "Gibraltar",
                    NameFrenchTranslation = "Gibraltar"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 78,
                        ISO2 = "GR",
                        ISO3 = "GRC",
                        CurrencyId = 52,
                        PhoneCode = "+30"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Greece",
                    NameFrenchTranslation = "Gr??ce"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 79,
                        ISO2 = "GL",
                        ISO3 = "GRL",
                        CurrencyId = 44,
                        PhoneCode = "+299"
                    },
                    NameArabicTranslation = "?????????? ??????????????",
                    NameEnglishTranslation = "Greenland",
                    NameFrenchTranslation = "Groenland"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 80,
                        ISO2 = "GD",
                        ISO3 = "GRD",
                        CurrencyId = 47,
                        PhoneCode = "+1473"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Grenada",
                    NameFrenchTranslation = "Grenade"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 81,
                        ISO2 = "GP",
                        ISO3 = "GLP",
                        CurrencyId = 52,
                        PhoneCode = "+590"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Guadeloupe",
                    NameFrenchTranslation = "Guadeloupe"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 82,
                        ISO2 = "GU",
                        ISO3 = "GUM",
                        CurrencyId = 155,
                        PhoneCode = "+1671"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Guam",
                    NameFrenchTranslation = "Guam"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 83,
                        ISO2 = "GT",
                        ISO3 = "GTM",
                        CurrencyId = 59,
                        PhoneCode = "+502"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Guatemala",
                    NameFrenchTranslation = "Guatemala"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 84,
                        ISO2 = "GG",
                        ISO3 = "GGY",
                        CurrencyId = 118,
                        PhoneCode = "+44"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Guernsey",
                    NameFrenchTranslation = "Guernesey"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 85,
                        ISO2 = "GN",
                        ISO3 = "GIN",
                        CurrencyId = 60,
                        PhoneCode = "+224"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Guinea",
                    NameFrenchTranslation = "Guin??e"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 86,
                        ISO2 = "GW",
                        ISO3 = "GNB",
                        CurrencyId = 30,
                        PhoneCode = "+245"
                    },
                    NameArabicTranslation = "?????????? ??????????",
                    NameEnglishTranslation = "Guinea-Bissau",
                    NameFrenchTranslation = "la Guin??e-Bissau"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 87,
                        ISO2 = "GY",
                        ISO3 = "GUY",
                        CurrencyId = 61,
                        PhoneCode = "+595"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Guyana",
                    NameFrenchTranslation = "Guyane"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 88,
                        ISO2 = "HT",
                        ISO3 = "HTI",
                        CurrencyId = 62,
                        PhoneCode = "+509"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Haiti",
                    NameFrenchTranslation = "Ha??ti"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 89,
                        ISO2 = "VA",
                        ISO3 = "VAT",
                        CurrencyId = 52,
                        PhoneCode = "+379"
                    },
                    NameArabicTranslation = "???????????? ?????????????? (?????????????????? ????",
                    NameEnglishTranslation = "Holy See (Vatican Ci",
                    NameFrenchTranslation = "Saint-Si??ge (Vatican Ci"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 90,
                        ISO2 = "HN",
                        ISO3 = "HND",
                        CurrencyId = 63,
                        PhoneCode = "+504"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Honduras",
                    NameFrenchTranslation = "Honduras"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 91,
                        ISO2 = "HK",
                        ISO3 = "HKG",
                        CurrencyId = 64,
                        PhoneCode = "+852"
                    },
                    NameArabicTranslation = "???????? ????????",
                    NameEnglishTranslation = "Hong Kong",
                    NameFrenchTranslation = "Hong Kong"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 92,
                        ISO2 = "HU",
                        ISO3 = "HUN",
                        CurrencyId = 65,
                        PhoneCode = "+36"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Hungary",
                    NameFrenchTranslation = "Hongrie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 93,
                        ISO2 = "IS",
                        ISO3 = "ISL",
                        CurrencyId = 66,
                        PhoneCode = "+354"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Iceland",
                    NameFrenchTranslation = "Islande"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 94,
                        ISO2 = "IN",
                        ISO3 = "IND",
                        CurrencyId = 67,
                        PhoneCode = "+91"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "India",
                    NameFrenchTranslation = "Inde"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 95,
                        ISO2 = "ID",
                        ISO3 = "IDN",
                        CurrencyId = 68,
                        PhoneCode = "+62"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Indonesia",
                    NameFrenchTranslation = "Indon??sie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 96,
                        ISO2 = "IR",
                        ISO3 = "IRN",
                        CurrencyId = 69,
                        PhoneCode = "+98"
                    },
                    NameArabicTranslation = "?????????? ?? ?????????????????? ??????????????????",
                    NameEnglishTranslation = "Iran, Islamic Republ",
                    NameFrenchTranslation = "Iran, R??publique islamique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 97,
                        ISO2 = "IQ",
                        ISO3 = "IRQ",
                        CurrencyId = 70,
                        PhoneCode = "+964"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Iraq",
                    NameFrenchTranslation = "Irak"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 98,
                        ISO2 = "IE",
                        ISO3 = "IRL",
                        CurrencyId = 52,
                        PhoneCode = "+353"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Ireland",
                    NameFrenchTranslation = "Irlande"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 99,
                        ISO2 = "IM",
                        ISO3 = "IMN",
                        CurrencyId = 118,
                        PhoneCode = "+44"
                    },
                    NameArabicTranslation = "?????????? ?????? ?????? ??????",
                    NameEnglishTranslation = "Isle of Man",
                    NameFrenchTranslation = "??le de Man"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 100,
                        ISO2 = "IT",
                        ISO3 = "ITA",
                        CurrencyId = 52,
                        PhoneCode = "+39"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Italy",
                    NameFrenchTranslation = "Italie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 101,
                        ISO2 = "JM",
                        ISO3 = "JAM",
                        CurrencyId = 71,
                        PhoneCode = "+1876"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Jamaica",
                    NameFrenchTranslation = "Jama??que"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 102,
                        ISO2 = "JP",
                        ISO3 = "JPN",
                        CurrencyId = 72,
                        PhoneCode = "+81"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Japan",
                    NameFrenchTranslation = "Japon"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 103,
                        ISO2 = "JE",
                        ISO3 = "JEY",
                        CurrencyId = 118,
                        PhoneCode = "+44"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Jersey",
                    NameFrenchTranslation = "Jersey"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 104,
                        ISO2 = "JO",
                        ISO3 = "JOR",
                        CurrencyId = 73,
                        PhoneCode = "+962"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Jordan",
                    NameFrenchTranslation = "Jordan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 105,
                        ISO2 = "KZ",
                        ISO3 = "KAZ",
                        CurrencyId = 74,
                        PhoneCode = "+7 7"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Kazakhstan",
                    NameFrenchTranslation = "Kazakhstan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 106,
                        ISO2 = "KE",
                        ISO3 = "KEN",
                        CurrencyId = 75,
                        PhoneCode = "+254"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Kenya",
                    NameFrenchTranslation = "Kenya"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 107,
                        ISO2 = "KI",
                        ISO3 = "KIR",
                        CurrencyId = 8,
                        PhoneCode = "+686"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Kiribati",
                    NameFrenchTranslation = "Kiribati"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 108,
                        ISO2 = "KP",
                        ISO3 = "PRK",
                        CurrencyId = 76,
                        PhoneCode = "+850"
                    },
                    NameArabicTranslation = "?????????? ?????????????????????? ????",
                    NameEnglishTranslation = "Korea, Democratic Pe",
                    NameFrenchTranslation = "Cor??e, Pe d??mocratique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 109,
                        ISO2 = "KR",
                        ISO3 = "KOR",
                        CurrencyId = 107,
                        PhoneCode = "+82"
                    },
                    NameArabicTranslation = "?????????????? ?????????? ????????????????",
                    NameEnglishTranslation = "Korea, Republic of S",
                    NameFrenchTranslation = "Cor??e, R??publique de S"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 110,
                        ISO2 = "KW",
                        ISO3 = "KWT",
                        CurrencyId = 77,
                        PhoneCode = "+965"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Kuwait",
                    NameFrenchTranslation = "Koweit"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 111,
                        ISO2 = "KG",
                        ISO3 = "KGZ",
                        CurrencyId = 78,
                        PhoneCode = "+996"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Kyrgyzstan",
                    NameFrenchTranslation = "Kirghizistan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 112,
                        ISO2 = "LA",
                        ISO3 = "LAO",
                        CurrencyId = 79,
                        PhoneCode = "+856"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Laos",
                    NameFrenchTranslation = "Laos"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 113,
                        ISO2 = "LV",
                        ISO3 = "LVA",
                        CurrencyId = 52,
                        PhoneCode = "+371"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Latvia",
                    NameFrenchTranslation = "Lettonie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 114,
                        ISO2 = "LB",
                        ISO3 = "LBN",
                        CurrencyId = 80,
                        PhoneCode = "+961"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Lebanon",
                    NameFrenchTranslation = "Liban"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 115,
                        ISO2 = "LS",
                        ISO3 = "LSO",
                        CurrencyId = 81,
                        PhoneCode = "+266"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Lesotho",
                    NameFrenchTranslation = "Lesotho"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 116,
                        ISO2 = "LR",
                        ISO3 = "LBR",
                        CurrencyId = 82,
                        PhoneCode = "+231"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Liberia",
                    NameFrenchTranslation = "Lib??ria"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 117,
                        ISO2 = "LY",
                        ISO3 = "LBY",
                        CurrencyId = 83,
                        PhoneCode = "+218"
                    },
                    NameArabicTranslation = "???????????????????? ?????????????? ??????????????",
                    NameEnglishTranslation = "Libyan Arab Jamahiri",
                    NameFrenchTranslation = "Jamahiri arabe libyen"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 118,
                        ISO2 = "LI",
                        ISO3 = "LIE",
                        CurrencyId = 141,
                        PhoneCode = "+423"
                    },
                    NameArabicTranslation = "????????????????????",
                    NameEnglishTranslation = "Liechtenstein",
                    NameFrenchTranslation = "Liechtenstein"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 119,
                        ISO2 = "LT",
                        ISO3 = "LTU",
                        CurrencyId = 52,
                        PhoneCode = "+370"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Lithuania",
                    NameFrenchTranslation = "Lituanie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 120,
                        ISO2 = "LU",
                        ISO3 = "LUX",
                        CurrencyId = 52,
                        PhoneCode = "+352"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Luxembourg",
                    NameFrenchTranslation = "Luxembourg"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 121,
                        ISO2 = "MK",
                        ISO3 = "MKD",
                        CurrencyId = 85,
                        PhoneCode = "+389"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Macedonia",
                    NameFrenchTranslation = "Mac??doine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 122,
                        ISO2 = "MW",
                        ISO3 = "MWI",
                        CurrencyId = 87,
                        PhoneCode = "+265"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Malawi",
                    NameFrenchTranslation = "Malawi"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 123,
                        ISO2 = "MY",
                        ISO3 = "MYS",
                        CurrencyId = 88,
                        PhoneCode = "+60"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Malaysia",
                    NameFrenchTranslation = "Malaisie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 124,
                        ISO2 = "MV",
                        ISO3 = "MDV",
                        CurrencyId = 89,
                        PhoneCode = "+960"
                    },
                    NameArabicTranslation = "?????? ????????????????",
                    NameEnglishTranslation = "Maldives",
                    NameFrenchTranslation = "Maldives"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 125,
                        ISO2 = "ML",
                        ISO3 = "MLI",
                        CurrencyId = 30,
                        PhoneCode = "+223"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Mali",
                    NameFrenchTranslation = "Mali"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 126,
                        ISO2 = "MT",
                        ISO3 = "MLT",
                        CurrencyId = 52,
                        PhoneCode = "+356"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Malta",
                    NameFrenchTranslation = "Malte"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 127,
                        ISO2 = "MH",
                        ISO3 = "MHL",
                        CurrencyId = 155,
                        PhoneCode = "+692"
                    },
                    NameArabicTranslation = "?????? ????????????",
                    NameEnglishTranslation = "Marshall Islands",
                    NameFrenchTranslation = "Iles Marshall"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 128,
                        ISO2 = "MQ",
                        ISO3 = "MTQ",
                        CurrencyId = 52,
                        PhoneCode = "+596"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Martinique",
                    NameFrenchTranslation = "Martinique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 129,
                        ISO2 = "MR",
                        ISO3 = "MRT",
                        CurrencyId = 90,
                        PhoneCode = "+222"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Mauritania",
                    NameFrenchTranslation = "Mauritanie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 130,
                        ISO2 = "MU",
                        ISO3 = "MUS",
                        CurrencyId = 91,
                        PhoneCode = "+230"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Mauritius",
                    NameFrenchTranslation = "Maurice"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 131,
                        ISO2 = "YT",
                        ISO3 = "MYT",
                        CurrencyId = 52,
                        PhoneCode = "+262"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Mayotte",
                    NameFrenchTranslation = "Mayotte"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 132,
                        ISO2 = "MX",
                        ISO3 = "MEX",
                        CurrencyId = 92,
                        PhoneCode = "+52"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Mexico",
                    NameFrenchTranslation = "Mexique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 133,
                        ISO2 = "FM",
                        ISO3 = "FSM",
                        CurrencyId = 155,
                        PhoneCode = "+691"
                    },
                    NameArabicTranslation = "???????????????????? ?? ????????????????????",
                    NameEnglishTranslation = "Micronesia, Federate",
                    NameFrenchTranslation = "Micron??sie, F??d??r??"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 134,
                        ISO2 = "MD",
                        ISO3 = "MDA",
                        CurrencyId = 94,
                        PhoneCode = "+373"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Moldova",
                    NameFrenchTranslation = "Moldavie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 135,
                        ISO2 = "MC",
                        ISO3 = "MCO",
                        CurrencyId = 52,
                        PhoneCode = "+377"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Monaco",
                    NameFrenchTranslation = "Monaco"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 136,
                        ISO2 = "MN",
                        ISO3 = "MNG",
                        CurrencyId = 95,
                        PhoneCode = "+976"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Mongolia",
                    NameFrenchTranslation = "Mongolie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 137,
                        ISO2 = "ME",
                        ISO3 = "MNE",
                        CurrencyId = 52,
                        PhoneCode = "+382"
                    },
                    NameArabicTranslation = "?????????? ????????????",
                    NameEnglishTranslation = "Montenegro",
                    NameFrenchTranslation = "Mont??n??gro"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 138,
                        ISO2 = "MS",
                        ISO3 = "MSR",
                        CurrencyId = 47,
                        PhoneCode = "+1664"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Montserrat",
                    NameFrenchTranslation = "Montserrat"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 139,
                        ISO2 = "MA",
                        ISO3 = "MAR",
                        CurrencyId = 96,
                        PhoneCode = "+212"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Morocco",
                    NameFrenchTranslation = "Maroc"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 140,
                        ISO2 = "MZ",
                        ISO3 = "MOZ",
                        CurrencyId = 97,
                        PhoneCode = "+258"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Mozambique",
                    NameFrenchTranslation = "Mozambique"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 141,
                        ISO2 = "MM",
                        ISO3 = "MMR",
                        CurrencyId = 98,
                        PhoneCode = "+95"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Myanmar",
                    NameFrenchTranslation = "Myanmar"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 142,
                        ISO2 = "NA",
                        ISO3 = "NAM",
                        CurrencyId = 99,
                        PhoneCode = "+264"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Namibia",
                    NameFrenchTranslation = "Namibie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 143,
                        ISO2 = "NR",
                        ISO3 = "NRU",
                        CurrencyId = 8,
                        PhoneCode = "+674"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Nauru",
                    NameFrenchTranslation = "Nauru"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 144,
                        ISO2 = "NP",
                        ISO3 = "NPL",
                        CurrencyId = 100,
                        PhoneCode = "+977"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Nepal",
                    NameFrenchTranslation = "N??pal"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 145,
                        ISO2 = "NL",
                        ISO3 = "NLD",
                        CurrencyId = 52,
                        PhoneCode = "+31"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Netherlands",
                    NameFrenchTranslation = "Pays-Bas"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 146,
                        ISO2 = "AN",
                        ISO3 = "ANT",
                        CurrencyId = 52,
                        PhoneCode = "+599"
                    },
                    NameArabicTranslation = "?????? ?????????????? ??????????????????",
                    NameEnglishTranslation = "Netherlands Antilles",
                    NameFrenchTranslation = "Antilles n??erlandaises"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 147,
                        ISO2 = "NC",
                        ISO3 = "NCL",
                        CurrencyId = 32,
                        PhoneCode = "+687"
                    },
                    NameArabicTranslation = "?????????????????? ??????????????",
                    NameEnglishTranslation = "New Caledonia",
                    NameFrenchTranslation = "Nouvelle Cal??donie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 148,
                        ISO2 = "NZ",
                        ISO3 = "NZL",
                        CurrencyId = 104,
                        PhoneCode = "+64"
                    },
                    NameArabicTranslation = "????????????????????",
                    NameEnglishTranslation = "New Zealand",
                    NameFrenchTranslation = "Nouvelle-Z??lande"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 149,
                        ISO2 = "NI",
                        ISO3 = "NIC",
                        CurrencyId = 105,
                        PhoneCode = "+505"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Nicaragua",
                    NameFrenchTranslation = "Nicaragua"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 150,
                        ISO2 = "NE",
                        ISO3 = "NER",
                        CurrencyId = 30,
                        PhoneCode = "+227"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Niger",
                    NameFrenchTranslation = "Niger"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 151,
                        ISO2 = "NG",
                        ISO3 = "NGA",
                        CurrencyId = 106,
                        PhoneCode = "+234"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Nigeria",
                    NameFrenchTranslation = "Nigeria"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 152,
                        ISO2 = "NU",
                        ISO3 = "NIU",
                        CurrencyId = 104,
                        PhoneCode = "+683"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Niue",
                    NameFrenchTranslation = "Niou??"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 153,
                        ISO2 = "MP",
                        ISO3 = "MNP",
                        CurrencyId = 155,
                        PhoneCode = "+1670"
                    },
                    NameArabicTranslation = "???????? ?????????????? ??????????",
                    NameEnglishTranslation = "Northern Mariana Isl",
                    NameFrenchTranslation = "Mariana du Nord"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 154,
                        ISO2 = "NO",
                        ISO3 = "NOR",
                        CurrencyId = 108,
                        PhoneCode = "+47"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Norway",
                    NameFrenchTranslation = "Norv??ge"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 155,
                        ISO2 = "OM",
                        ISO3 = "OMN",
                        CurrencyId = 120,
                        PhoneCode = "+968"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Oman",
                    NameFrenchTranslation = "Oman"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 156,
                        ISO2 = "PK",
                        ISO3 = "PAK",
                        CurrencyId = 109,
                        PhoneCode = "+92"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Pakistan",
                    NameFrenchTranslation = "Pakistan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 157,
                        ISO2 = "PW",
                        ISO3 = "PLW",
                        CurrencyId = 155,
                        PhoneCode = "+680"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Palau",
                    NameFrenchTranslation = "Palau"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 158,
                        ISO2 = "PA",
                        ISO3 = "PAN",
                        CurrencyId = 110,
                        PhoneCode = "+507"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Panama",
                    NameFrenchTranslation = "Panama"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 159,
                        ISO2 = "PG",
                        ISO3 = "PNG",
                        CurrencyId = 111,
                        PhoneCode = "+675"
                    },
                    NameArabicTranslation = "?????????? ?????????? ??????????????",
                    NameEnglishTranslation = "Papua New Guinea",
                    NameFrenchTranslation = "Papouasie Nouvelle Guin??e"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 160,
                        ISO2 = "PY",
                        ISO3 = "PRY",
                        CurrencyId = 112,
                        PhoneCode = "+595"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Paraguay",
                    NameFrenchTranslation = "Paraguay"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 161,
                        ISO2 = "PE",
                        ISO3 = "PER",
                        CurrencyId = 113,
                        PhoneCode = "+51"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Peru",
                    NameFrenchTranslation = "P??rou"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 162,
                        ISO2 = "PH",
                        ISO3 = "PHL",
                        CurrencyId = 116,
                        PhoneCode = "+63"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Philippines",
                    NameFrenchTranslation = "Philippines"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 163,
                        ISO2 = "PN",
                        ISO3 = "PCN",
                        CurrencyId = 104,
                        PhoneCode = "+872"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Pitcairn",
                    NameFrenchTranslation = "Pitcairn"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 164,
                        ISO2 = "PL",
                        ISO3 = "POL",
                        CurrencyId = 117,
                        PhoneCode = "+48"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Poland",
                    NameFrenchTranslation = "Pologne"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 165,
                        ISO2 = "PT",
                        ISO3 = "PRT",
                        CurrencyId = 52,
                        PhoneCode = "+351"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Portugal",
                    NameFrenchTranslation = "le Portugal"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 166,
                        ISO2 = "PR",
                        ISO3 = "PRI",
                        CurrencyId = 155,
                        PhoneCode = "+1939"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Puerto Rico",
                    NameFrenchTranslation = "Porto Rico"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 167,
                        ISO2 = "QA",
                        ISO3 = "QAT",
                        CurrencyId = 119,
                        PhoneCode = "+974"
                    },
                    NameArabicTranslation = "???????? ??????",
                    NameEnglishTranslation = "Qatar",
                    NameFrenchTranslation = "Qatar"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 168,
                        ISO2 = "RE",
                        ISO3 = "REU",
                        CurrencyId = 52,
                        PhoneCode = "+262"
                    },
                    NameArabicTranslation = "?????? ??????",
                    NameEnglishTranslation = "Reunion",
                    NameFrenchTranslation = "R??union"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 169,
                        ISO2 = "RO",
                        ISO3 = "ROU",
                        CurrencyId = 121,
                        PhoneCode = "+40"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Romania",
                    NameFrenchTranslation = "Roumanie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 170,
                        ISO2 = "RU",
                        ISO3 = "RUS",
                        CurrencyId = 122,
                        PhoneCode = "+7"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Russia",
                    NameFrenchTranslation = "Russie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 171,
                        ISO2 = "RW",
                        ISO3 = "RWA",
                        CurrencyId = 123,
                        PhoneCode = "+250"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Rwanda",
                    NameFrenchTranslation = "Rwanda"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 172,
                        ISO2 = "SH",
                        ISO3 = "SHN",
                        CurrencyId = 124,
                        PhoneCode = "+290"
                    },
                    NameArabicTranslation = "???????? ???????????? ?? ??????????",
                    NameEnglishTranslation = "Saint Helena, Ascens",
                    NameFrenchTranslation = "Sainte-H??l??ne, Ascensions"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 173,
                        ISO2 = "KN",
                        ISO3 = "KNA",
                        CurrencyId = 47,
                        PhoneCode = "+1869"
                    },
                    NameArabicTranslation = "???????? ???????? ??????????",
                    NameEnglishTranslation = "Saint Kitts and Nevi",
                    NameFrenchTranslation = "Saint-Kitts-et-Nevi"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 174,
                        ISO2 = "LC",
                        ISO3 = "LCA",
                        CurrencyId = 47,
                        PhoneCode = "+1758"
                    },
                    NameArabicTranslation = "???????? ??????????",
                    NameEnglishTranslation = "Saint Lucia",
                    NameFrenchTranslation = "Saint Lucia"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 175,
                        ISO2 = "WS",
                        ISO3 = "WSM",
                        CurrencyId = 125,
                        PhoneCode = "+685"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Samoa",
                    NameFrenchTranslation = "Samoa"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 176,
                        ISO2 = "SM",
                        ISO3 = "SMR",
                        CurrencyId = 52,
                        PhoneCode = "+378"
                    },
                    NameArabicTranslation = "?????? ????????????",
                    NameEnglishTranslation = "San Marino",
                    NameFrenchTranslation = "Saint-Marin"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 177,
                        ISO2 = "SA",
                        ISO3 = "SAU",
                        CurrencyId = 127,
                        PhoneCode = "+966"
                    },
                    NameArabicTranslation = "?????????????? ?????????????? ????????????????",
                    NameEnglishTranslation = "Saudi Arabia",
                    NameFrenchTranslation = "Arabie Saoudite"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 178,
                        ISO2 = "SN",
                        ISO3 = "SEN",
                        CurrencyId = 30,
                        PhoneCode = "+221"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Senegal",
                    NameFrenchTranslation = "S??n??gal"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 179,
                        ISO2 = "RS",
                        ISO3 = "SRB",
                        CurrencyId = 128,
                        PhoneCode = "+381"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Serbia",
                    NameFrenchTranslation = "Serbie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 180,
                        ISO2 = "SC",
                        ISO3 = "SYC",
                        CurrencyId = 129,
                        PhoneCode = "+248"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Seychelles",
                    NameFrenchTranslation = "les Seychelles"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 181,
                        ISO2 = "SG",
                        ISO3 = "SGP",
                        CurrencyId = 23,
                        PhoneCode = "+65"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Singapore",
                    NameFrenchTranslation = "Singapour"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 182,
                        ISO2 = "SK",
                        ISO3 = "SVK",
                        CurrencyId = 52,
                        PhoneCode = "+421"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Slovakia",
                    NameFrenchTranslation = "Slovaquie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 183,
                        ISO2 = "SI",
                        ISO3 = "SVN",
                        CurrencyId = 52,
                        PhoneCode = "+386"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Slovenia",
                    NameFrenchTranslation = "Slov??nie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 184,
                        ISO2 = "SB",
                        ISO3 = "SLB",
                        CurrencyId = 132,
                        PhoneCode = "+677"
                    },
                    NameArabicTranslation = "?????? ????????????",
                    NameEnglishTranslation = "Solomon Islands",
                    NameFrenchTranslation = "Les ??les Salomon"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 185,
                        ISO2 = "SO",
                        ISO3 = "SOM",
                        CurrencyId = 133,
                        PhoneCode = "+252"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Somalia",
                    NameFrenchTranslation = "Somalie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 186,
                        ISO2 = "ZA",
                        ISO3 = "ZAF",
                        CurrencyId = 134,
                        PhoneCode = "+27"
                    },
                    NameArabicTranslation = "???????? ??????????????",
                    NameEnglishTranslation = "South Africa",
                    NameFrenchTranslation = "Afrique du Sud"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 187,
                        ISO2 = "ES",
                        ISO3 = "ESP",
                        CurrencyId = 52,
                        PhoneCode = "+34"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Spain",
                    NameFrenchTranslation = "Espagne"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 188,
                        ISO2 = "LK",
                        ISO3 = "LKA",
                        CurrencyId = 136,
                        PhoneCode = "+94"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Sri Lanka",
                    NameFrenchTranslation = "Sri Lanka"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 189,
                        ISO2 = "SD",
                        ISO3 = "SDN",
                        CurrencyId = 137,
                        PhoneCode = "+249"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Sudan",
                    NameFrenchTranslation = "Soudan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 190,
                        ISO2 = "SR",
                        ISO3 = "SUR",
                        CurrencyId = 138,
                        PhoneCode = "+597"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Suriname",
                    NameFrenchTranslation = "Suriname"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 191,
                        ISO2 = "SZ",
                        ISO3 = "SWZ",
                        CurrencyId = 139,
                        PhoneCode = "+268"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Swaziland",
                    NameFrenchTranslation = "Swaziland"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 192,
                        ISO2 = "SE",
                        ISO3 = "SWE",
                        CurrencyId = 140,
                        PhoneCode = "+46"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Sweden",
                    NameFrenchTranslation = "Su??de"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 193,
                        ISO2 = "CH",
                        ISO3 = "CHE",
                        CurrencyId = 141,
                        PhoneCode = "+41"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Switzerland",
                    NameFrenchTranslation = "Suisse"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 194,
                        ISO2 = "SY",
                        ISO3 = "SYR",
                        CurrencyId = 142,
                        PhoneCode = "+963"
                    },
                    NameArabicTranslation = "?????????????????? ?????????????? ??????????????",
                    NameEnglishTranslation = "Syrian Arab Republic",
                    NameFrenchTranslation = "R??publique arabe syrienne"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 195,
                        ISO2 = "TW",
                        ISO3 = "TWN",
                        CurrencyId = 103,
                        PhoneCode = "+886"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Taiwan",
                    NameFrenchTranslation = "Ta??wan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 196,
                        ISO2 = "TJ",
                        ISO3 = "TJK",
                        CurrencyId = 143,
                        PhoneCode = "+992"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Tajikistan",
                    NameFrenchTranslation = "Tadjikistan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 197,
                        ISO2 = "TH",
                        ISO3 = "THA",
                        CurrencyId = 145,
                        PhoneCode = "+66"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Thailand",
                    NameFrenchTranslation = "Tha??lande"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 198,
                        ISO2 = "TL",
                        ISO3 = "TLS",
                        CurrencyId = 155,
                        PhoneCode = "+670"
                    },
                    NameArabicTranslation = "?????????? ??????????????",
                    NameEnglishTranslation = "Timor-Leste",
                    NameFrenchTranslation = "Timor-Leste"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 199,
                        ISO2 = "TG",
                        ISO3 = "TGO",
                        CurrencyId = 30,
                        PhoneCode = "+228"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Togo",
                    NameFrenchTranslation = "Aller"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 200,
                        ISO2 = "TK",
                        ISO3 = "TKL",
                        CurrencyId = 104,
                        PhoneCode = "+690"
                    },
                    NameArabicTranslation = "??????????????",
                    NameEnglishTranslation = "Tokelau",
                    NameFrenchTranslation = "Tokelau"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 201,
                        ISO2 = "TO",
                        ISO3 = "TON",
                        CurrencyId = 146,
                        PhoneCode = "+676"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Tonga",
                    NameFrenchTranslation = "Tonga"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 202,
                        ISO2 = "TT",
                        ISO3 = "TTO",
                        CurrencyId = 147,
                        PhoneCode = "+1868"
                    },
                    NameArabicTranslation = "?????????????? ??????????????",
                    NameEnglishTranslation = "Trinidad and Tobago",
                    NameFrenchTranslation = "Trinit??-et-Tobago"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 203,
                        ISO2 = "TN",
                        ISO3 = "TUN",
                        CurrencyId = 148,
                        PhoneCode = "+216"
                    },
                    NameArabicTranslation = "????????",
                    NameEnglishTranslation = "Tunisia",
                    NameFrenchTranslation = "Tunisie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 204,
                        ISO2 = "TR",
                        ISO3 = "TUR",
                        CurrencyId = 149,
                        PhoneCode = "+90"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Turkey",
                    NameFrenchTranslation = "Turquie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 205,
                        ISO2 = "TC",
                        ISO3 = "TCA",
                        CurrencyId = 155,
                        PhoneCode = "+1649"
                    },
                    NameArabicTranslation = "?????? ???????? ??????????????",
                    NameEnglishTranslation = "Turks and Caicos Isl",
                    NameFrenchTranslation = "??les Turques et Ca??ques"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 206,
                        ISO2 = "TV",
                        ISO3 = "TUV",
                        CurrencyId = 8,
                        PhoneCode = "+688"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Tuvalu",
                    NameFrenchTranslation = "Tuvalu"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 207,
                        ISO2 = "UG",
                        ISO3 = "UGA",
                        CurrencyId = 152,
                        PhoneCode = "+256"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Uganda",
                    NameFrenchTranslation = "Ouganda"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 208,
                        ISO2 = "UA",
                        ISO3 = "UKR",
                        CurrencyId = 153,
                        PhoneCode = "+380"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Ukraine",
                    NameFrenchTranslation = "Ukraine"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 209,
                        ISO2 = "AE",
                        ISO3 = "ARE",
                        CurrencyId = 151,
                        PhoneCode = "+971"
                    },
                    NameArabicTranslation = "???????????????? ?????????????? ??????????????",
                    NameEnglishTranslation = "United Arab Emirates",
                    NameFrenchTranslation = "Emirats Arabes Unis"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 210,
                        ISO2 = "GB",
                        ISO3 = "GBR",
                        CurrencyId = 118,
                        PhoneCode = "+44"
                    },
                    NameArabicTranslation = "?????????????? ??????????????",
                    NameEnglishTranslation = "United Kingdom",
                    NameFrenchTranslation = "Royaume-Uni"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 211,
                        ISO2 = "US",
                        ISO3 = "USA",
                        CurrencyId = 155,
                        PhoneCode = "+1"
                    },
                    NameArabicTranslation = "???????????????? ?????????????? ??????????????????",
                    NameEnglishTranslation = "United States",
                    NameFrenchTranslation = "??tats Unis"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 212,
                        ISO2 = "UY",
                        ISO3 = "URY",
                        CurrencyId = 115,
                        PhoneCode = "+598"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Uruguay",
                    NameFrenchTranslation = "Uruguay"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 213,
                        ISO2 = "UZ",
                        ISO3 = "UZB",
                        CurrencyId = 157,
                        PhoneCode = "+998"
                    },
                    NameArabicTranslation = "??????????????????",
                    NameEnglishTranslation = "Uzbekistan",
                    NameFrenchTranslation = "Ouzb??kistan"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 214,
                        ISO2 = "VE",
                        ISO3 = "VEN",
                        CurrencyId = 159,
                        PhoneCode = "+58"
                    },
                    NameArabicTranslation = "?????????????? ?? ??????????????",
                    NameEnglishTranslation = "Venezuela, Bolivaria",
                    NameFrenchTranslation = "Venezuela, Bolivie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 215,
                        ISO2 = "VN",
                        ISO3 = "VNM",
                        CurrencyId = 160,
                        PhoneCode = "+84"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Vietnam",
                    NameFrenchTranslation = "Vietnam"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 216,
                        ISO2 = "VG",
                        ISO3 = "VGB",
                        CurrencyId = 155,
                        PhoneCode = "+1284"
                    },
                    NameArabicTranslation = "?????? ?????????? ?? ????????",
                    NameEnglishTranslation = "Virgin Islands, Brit",
                    NameFrenchTranslation = "Iles Vierges britanniques"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 217,
                        ISO2 = "VI",
                        ISO3 = "VIR",
                        CurrencyId = 155,
                        PhoneCode = "+1340"
                    },
                    NameArabicTranslation = "?????? ?????????? ?? ???????????????? ??????????????",
                    NameEnglishTranslation = "Virgin Islands, U.S.",
                    NameFrenchTranslation = "??les Vierges am??ricaines"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 218,
                        ISO2 = "WF",
                        ISO3 = "WLF",
                        CurrencyId = 32,
                        PhoneCode = "+681"
                    },
                    NameArabicTranslation = "?????????? ??????????????",
                    NameEnglishTranslation = "Wallis and Futuna",
                    NameFrenchTranslation = "Wallis et Futuna"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 219,
                        ISO2 = "YE",
                        ISO3 = "YEM",
                        CurrencyId = 163,
                        PhoneCode = "+967"
                    },
                    NameArabicTranslation = "??????????",
                    NameEnglishTranslation = "Yemen",
                    NameFrenchTranslation = "Y??men"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 220,
                        ISO2 = "ZM",
                        ISO3 = "ZMB",
                        CurrencyId = 164,
                        PhoneCode = "+260"
                    },
                    NameArabicTranslation = "????????????",
                    NameEnglishTranslation = "Zambia",
                    NameFrenchTranslation = "Zambie"
                },
                new CountryLocalizable
                {
                    CountryObj = new Country
                    {
                        Id = 221,
                        ISO2 = "ZW",
                        ISO3 = "ZWE",
                        CurrencyId = 21,
                        PhoneCode = "+263"
                    },
                    NameArabicTranslation = "????????????????",
                    NameEnglishTranslation = "Zimbabwe",
                    NameFrenchTranslation = "Zimbabwe"
                }
            };

        private class CountryLocalizable
        {
            public Country CountryObj { get; set; }

            public string NameEnglishTranslation { get; set; }

            public string NameArabicTranslation { get; set; }

            public string NameFrenchTranslation { get; set; }
        }
    }
}
