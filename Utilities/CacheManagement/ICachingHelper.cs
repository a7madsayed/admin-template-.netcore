namespace CompanyName.CacheManagement
{
    /// <summary>
    /// Responsible for caching elements in store
    /// </summary>
    public interface ICachingHelper
    {
        /// <summary>
        /// Gets cahced item by key
        /// </summary>
        /// <typeparam name="T">Type of returned item</typeparam>
        /// <param name="key">Cache Key</param>
        /// <returns>Value of cached key</returns>
        T Get<T>(string key);

        /// <summary>
        /// Sets value in cache
        /// </summary>
        /// <param name="key">Key of element to be set in cache</param>
        /// <param name="data">data to be cached</param>
        void Set(string key, object data);

        /// <summary>
        /// Check whether an element cached by passed key
        /// </summary>
        /// <param name="key">Ket to check with</param>
        /// <returns>True if exists, false if not</returns>
        bool Contains(string key);

        /// <summary>
        /// Removes certain element from cache using the provided key
        /// </summary>
        /// <param name="key">Key of element to remove</param>
        void Remove(string key);

        /// <summary>
        /// Clear all elements from cache
        /// </summary>
        void Clear();
    }
}
