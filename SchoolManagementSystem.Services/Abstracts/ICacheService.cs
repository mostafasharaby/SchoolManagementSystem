namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ICacheService
    {
        Task<List<T>> GetOrAddToCacheAsync<T>(string cacheKey, Func<Task<List<T>>> getData, int expirationInSeconds);
    }
}
