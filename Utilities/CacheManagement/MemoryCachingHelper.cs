namespace CompanyName.CacheManagement
{
    using System;
    using System.Threading;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Primitives;

    internal class MemoryCachingHelper : ICachingHelper, IDisposable
    {
        private CancellationTokenSource _CancellationTokenSource;

        public MemoryCachingHelper() => _CancellationTokenSource = new CancellationTokenSource();

        private MemoryCache Cache => new MemoryCache(new MemoryCacheOptions
        {
            SizeLimit = 1024
        });

        /// <inheritdoc/>
        public T Get<T>(string key) => Cache.Get<T>(key);

        /// <inheritdoc/>
        public void Set(string key, object data)
        {
            if (data == null)
            {
                return;
            }

            Cache.Set(key, data, new CancellationChangeToken(_CancellationTokenSource.Token));
        }

        /// <inheritdoc/>
        public bool Contains(string key) => Cache.TryGetValue(key, out var result);

        /// <inheritdoc/>
        public void Remove(string key) => Cache.Remove(key);

        /// <inheritdoc/>
        public void Clear()
        {
            if (_CancellationTokenSource != null && !_CancellationTokenSource.IsCancellationRequested && _CancellationTokenSource.Token.CanBeCanceled)
            {
                _CancellationTokenSource.Cancel();
                _CancellationTokenSource.Dispose();
            }

            _CancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_CancellationTokenSource != null)
                {
                    _CancellationTokenSource.Dispose();
                }
            }
        }
    }
}
