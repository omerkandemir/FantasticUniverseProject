namespace NLayer.Core.CrossCuttingConcern.Caching;

public interface ICacheManager
{
    T Get<T>(string key);
    void Add(string key, object data, int duration);
    bool IsAdd(string key);
    void Remove(string key);
    void RemoveByPattern(string pattern);

    // Asenkron metotlar
    Task<T> GetAsync<T>(string key);
    Task AddAsync(string key, object data, int duration);
    Task<bool> IsAddAsync(string key);
    Task RemoveAsync(string key);
    Task RemoveByPatternAsync(string pattern);
}
