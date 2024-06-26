﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace LazyCache
{
    public interface ICacheProvider : IDisposable
    {
        void Set(string key, object item, MemoryCacheEntryOptions policy);
        object Get(string key);
        object GetOrCreate<T>(string key, Func<ICacheEntry, T> func);
        object GetOrCreate<T>(string key, MemoryCacheEntryOptions policy, Func<ICacheEntry, T> func);
        void Remove(string key);
        Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> func);
        bool TryGetValue<T>(object key, out T value);
        void Compact(double percentage);
    }
}