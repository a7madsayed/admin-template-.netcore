namespace CompanyName.ProductName.Admin.Data.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.ProductName.Admin.Data.Entities;

    /// <summary>
    /// Provides utilities for mapping properties of type <see cref="Translation"/> using auto mapper.
    /// </summary>
    public static class TranslationMapper
    {
        /// <summary>
        /// Creates a translation expression for mapping a <see cref="Entities.Translation"/> property on an entity to a string
        /// based on a "languageId" parameter that must be passed during projection (using
        /// AutoMapper.IQueryableExtensions.ProjectTo)
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <typeparam name="TTranslation">The entity type for a translation</typeparam>
        /// <typeparam name="TTranslationEntry">The entity type for a translation entry</typeparam>
        /// <param name="translationPropertyLambdaExpression">
        /// A lambda expression identifying the translation property, e.g. <code>e => e.NameTranslation</code>
        /// </param>
        /// <param name="languageFilterLambdaExpression">A lambda expression for filtering translation entries based on language.</param>
        /// <param name="translationEntriesPropertyName">Name of the property used to access translation entries.</param>
        /// <param name="translationValuePropertyName">Name of the property used to access the translation for a translation entry.</param>
        /// <returns>
        /// An expression tree representing the expression:
        /// <code>
        /// entity =} entity.NameTranslation.TranslationEntries.FirstOrDefault(e =} e.LanguageID == languageId)
        /// .Translation ?? entity.NameTranslation.DefaultValue))
        /// </code>
        /// </returns>
        public static Expression<Func<TEntity, string>> TranslationExpression<TEntity, TTranslation, TTranslationEntry>(
            Expression<Func<TEntity, TTranslation>> translationPropertyLambdaExpression,
            Expression<Func<TTranslationEntry, bool>> languageFilterLambdaExpression,
            string translationEntriesPropertyName = "TranslationEntries",
            string translationValuePropertyName = "Translation")
        {
            // entity
            if (translationPropertyLambdaExpression.Parameters.Count != 1)
            {
                throw new InvalidOperationException("Property expression must have one parameter");
            }

            var entityParam = translationPropertyLambdaExpression.Parameters[0];

            // Extract the body from the property lambda
            var nameTranslationExpression = translationPropertyLambdaExpression.Body as MemberExpression;
            if (nameTranslationExpression == null)
            {
                throw new InvalidOperationException("Property expression must be a MemberExpression");
            }

            var propertyInfo = nameTranslationExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new InvalidOperationException("Property expression must indicate a property");
            }

            // entity.NameTranslation.TranslationEntries
            var translationEntriesExpression = Expression.Property(nameTranslationExpression, translationEntriesPropertyName);

            // entity.NameTranslation.TranslationEntries.FirstOrDefault(e => e.LanguageID == languageId)
            var firstOrDefaultExpression = Expression.Call(
                typeof(Enumerable),
                "FirstOrDefault",
                new[] { typeof(TTranslationEntry) },
                translationEntriesExpression,
                languageFilterLambdaExpression);

            // entity.NameTranslation.TranslationEntries.FirstOrDefault(e => e.LanguageID == languageId).Translation
            // {firstExpression}
            var translationPropertyExpression = Expression.Property(firstOrDefaultExpression, translationValuePropertyName);

            // entity.NameTranslation.DefaultValue
            // {secondExpression}
            var defaultTranslationExpression = Expression.Property(nameTranslationExpression, "DefaultValue");

            // {firstExpression} ?? {secondExpression}
            var nullCoalescingExpression = Expression.Coalesce(translationPropertyExpression, defaultTranslationExpression);

            // entity => {firstExpression} ?? {secondExpression}
            var entityTranslationLambda = Expression.Lambda<Func<TEntity, string>>(nullCoalescingExpression, new[] { entityParam });
            return entityTranslationLambda;
        }

        /// <summary>
        /// Gets a parameter dictionary for use with <see cref="ProjectWithLanguageTo{TDestination}"/>.
        /// </summary>
        /// <param name="languageId">Language Id to use for project.</param>
        /// <returns>A parameter dictionary.</returns>
        public static Dictionary<string, object> GetQueryParameters(int languageId) => new Dictionary<string, object> { { "languageId", languageId } };

        /// <summary>
        /// Extension method for AutoMapper IMemberConfigurationExpression that simplifies mapping translations.
        /// </summary>
        /// <typeparam name="TSource">The source (entity) type.</typeparam>
        /// <typeparam name="TDestination">The destination (domain model) type.</typeparam>
        /// <param name="memberExpression">A mapping member expression, e.g. <code>CreateMap().ForMember(..., opt => opt.MapFromTranslation(...))</code></param>
        /// <param name="translationPropertyLambdaExpression">A lambda whose body is the translation property, e.g. <code>e => e.NameTranslation</code></param>
        public static void MapFromTranslation<TSource, TDestination>(
            this IMemberConfigurationExpression<TSource, TDestination, string> memberExpression,
            Expression<Func<TSource, Translation>> translationPropertyLambdaExpression)
        {
            // Dummy variable needed for generating the proper query expression tree.
            // It has to be passed during projection later using a parameters dictionary.
            // See WorkshopRepository.GetWorkshop for an example.
            var languageId = 0;
            Expression<Func<Entities.TranslationEntry, bool>> languageFilterLambdaExpression = e => e.LanguageId == languageId;
            memberExpression.MapFrom(TranslationExpression(translationPropertyLambdaExpression, languageFilterLambdaExpression));
        }

        /// <summary>
        /// Extension method for IQueryable that projects to a destination type with a language Id parameter.
        /// </summary>
        /// <typeparam name="TDestination">Destination type.</typeparam>
        /// <param name="query">The source query.</param>
        /// <param name="languageId">The language Id.</param>
        /// <returns>A query projected to the destination type.</returns>
        public static IQueryable<TDestination> ProjectWithLanguageTo<TDestination>(
            this IQueryable query,
            int languageId) => query.ProjectTo<TDestination>(GetQueryParameters(languageId));
    }
}
