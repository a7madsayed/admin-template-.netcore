namespace CompanyName.ProductName.Admin.Data.Dataseed.SeedManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using CompanyName.ProductName.Admin.Core;
    using CompanyName.ProductName.Admin.Data.Entities;

    public class Translator
    {
        private readonly Dictionary<PropertyInfo, object> _getterDictionary = new Dictionary<PropertyInfo, object>();
        private readonly Dictionary<PropertyInfo, object> _setterDictionary = new Dictionary<PropertyInfo, object>();
        private readonly ApplicationDBContext _DbContext;

        public Translator(ApplicationDBContext dbContext) => _DbContext = dbContext;

        public void Translate<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, Translation>> translationExpression,
            string defaultValue)
        {
            if (defaultValue == null)
            {
                throw new ArgumentNullException(nameof(defaultValue));
            }

            Func<TEntity, Translation> getter;
            Action<TEntity, object> setter;
            GetPropertyAccessors(translationExpression, out getter, out setter);

            var translation = getter(entity);
            if (translation == null)
            {
                translation = new Translation();
                _DbContext.Translations.Add(translation);
            }
            translation.DefaultValue = defaultValue;

            setter(entity, translation);
        }

        public void Translate<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, Translation>> translationExpression,
            SupportedLanguages language,
            string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Func<TEntity, Translation> getter;
            Action<TEntity, object> setter;
            GetPropertyAccessors(translationExpression, out getter, out setter);

            var translation = getter(entity);
            if (translation == null)
            {
                if (language != SupportedLanguages.English)
                    throw new InvalidOperationException("Entity has no translation");

                Translate(entity, translationExpression, value);
                translation = getter(entity);
            }

            if (language == SupportedLanguages.English)
                translation.DefaultValue = value;

            var entry = translation.TranslationEntries.SingleOrDefault(e => e.LanguageId == (int)language);
            if (entry == null)
            {
                entry = new TranslationEntry
                {
                    LanguageId = (int)language,
                };
                translation.TranslationEntries.Add(entry);
            }
            entry.Translation = value;
        }

        public void GetPropertyAccessors<TEntity, TProperty>(
            Expression<Func<TEntity, TProperty>> propertyExpression,
            out Func<TEntity, TProperty> getter,
            out Action<TEntity, object> setter)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Property expression must be a MemberExpression");

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new InvalidOperationException("Property expression must indicate a property");

            if (_getterDictionary.ContainsKey(propertyInfo))
            {
                getter = (Func<TEntity, TProperty>)_getterDictionary[propertyInfo];
            }
            else
            {
                if (!propertyInfo.CanRead)
                    throw new InvalidOperationException("Property must be readable");

                getter = propertyInfo.GetValueGetter<TEntity, TProperty>();
                _getterDictionary.Add(propertyInfo, getter);
            }

            if (_setterDictionary.ContainsKey(propertyInfo))
            {
                setter = propertyInfo.GetValueSetter<TEntity>();
            }
            else
            {
                if (!propertyInfo.CanWrite)
                    throw new InvalidOperationException("Property must be writeable");

                setter = propertyInfo.GetValueSetter<TEntity>();
                _setterDictionary.Add(propertyInfo, setter);
            }
        }

        public void RemoveTranslation<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, Translation>> translationExpression)
        {
            Func<TEntity, Translation> getter;
            Action<TEntity, object> setter;
            GetPropertyAccessors(translationExpression, out getter, out setter);

            var translation = getter(entity);
            if (translation == null)
                return;

            var entries = translation.TranslationEntries.ToList();
            translation.TranslationEntries.Clear();
            entries.ForEach(e => _DbContext.TranslationEntries.Remove(e));

            setter(entity, null);
            _DbContext.Translations.Remove(translation);
        }
    }
}
