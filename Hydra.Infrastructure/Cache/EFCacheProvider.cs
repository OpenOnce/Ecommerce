﻿
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Extensions.DependencyInjection;


namespace Hydra.Infrastructure.Cache
{
    /// <summary>
    /// EF Second Level Cache
    /// </summary>
    public static class EFCacheProvider
    {
        public const string CacheKeyPrefix = "Hydra_C";
        public const string ProviderName = "Hydra_P";
        /// <summary>
        /// Add EF Second Level Cache By EasyCaching
        /// In-Memory Or Redis
        /// </summary>
        /// <param name="services"></param>
        public static void AddEFCacheProvider(this IServiceCollection services)
        {
            services.AddEFSecondLevelCache(options =>
               options.UseEasyCachingCoreProvider(ProviderName)
               .ConfigureLogging(false)
               .UseCacheKeyPrefix(CacheKeyPrefix)
               .UseDbCallsIfCachingProviderIsDown(TimeSpan.FromMinutes(1))
           // Please use the `CacheManager.Core` or `EasyCaching.Redis` for the Redis cache provider.
           );
        }
        /// <summary>
        /// Add EF Second Level Cache By In-Memory
        /// </summary>
        /// <param name="services"></param>
        public static void AddInMemoryEFCacheProvider(this IServiceCollection services)
        {
            services.AddEFSecondLevelCache(options =>
               options.UseMemoryCacheProvider()
               .ConfigureLogging(false)
               .UseCacheKeyPrefix(CacheKeyPrefix)
               .UseDbCallsIfCachingProviderIsDown(TimeSpan.FromMinutes(1))
           // Please use the `CacheManager.Core` or `EasyCaching.Redis` for the Redis cache provider.
           );
        }
    }
}
