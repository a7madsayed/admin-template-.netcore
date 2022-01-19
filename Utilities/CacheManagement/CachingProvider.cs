namespace CompanyName.CacheManagement
{
    public static class CachingProvider
    {
        private static ICachingHelper _CachingHelper;

        public static ICachingHelper GetCachingProvider(CachingTypes cachingType)
        {
            if (_CachingHelper == null)
            {
                switch (cachingType)
                {
                    case CachingTypes.Memory:
                        _CachingHelper = new MemoryCachingHelper();
                        break;
                }
            }

            return _CachingHelper;
        }
    }
}
