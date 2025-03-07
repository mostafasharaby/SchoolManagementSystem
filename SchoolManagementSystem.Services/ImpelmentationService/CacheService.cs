using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SchoolManagementSystem.Services.Abstracts;
using System.Diagnostics;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IMemoryCache cache, ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<List<T>> GetOrAddToCacheAsync<T>(string cacheKey, Func<Task<List<T>>> getData, int expirationInSeconds = 30)
    {
        var stopwatch = Stopwatch.StartNew();

        if (_cache.TryGetValue(cacheKey, out List<T>? cachedData) && cachedData != null)
        {
            _logger.LogInformation("{CacheKey} found in cache.", cacheKey);
        }
        else
        {
            _logger.LogInformation("{CacheKey} not found in cache. Fetching from database...", cacheKey);
            cachedData = await getData(); // this will goes to the repo  
            _cache.Set(cacheKey, cachedData, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationInSeconds)
            });
        }

        stopwatch.Stop();
        _logger.LogWarning("Elapsed Time for {CacheKey}: {Elapsed} ms", cacheKey, stopwatch.ElapsedMilliseconds);

        return cachedData!;
    }

}
