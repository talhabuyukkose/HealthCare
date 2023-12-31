﻿using HealthCare.Core.Interfaces.Cache;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Cache
{
    public class MemoryService : IMemoryService
    {
        private readonly IMemoryCache memoryCache;

        public MemoryService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public ICacheEntry CreateEntry(object key)
        {
            return memoryCache.CreateEntry(key);
        }

        public void Set(object key, object value, TimeSpan timeSpan)
        {
            var options = new MemoryCacheEntryOptions
            {
                //AbsoluteExpiration = dateTime,
                AbsoluteExpirationRelativeToNow = timeSpan,
                Priority = CacheItemPriority.Normal,
            };

            memoryCache.Set(key, value, options);
        }
        public void Dispose()
        {
            memoryCache.Dispose();
        }

        public void Remove(object key)
        {
            memoryCache.Remove(key);
        }

        public bool TryGetValue(object key, out object? value)
        {
            return memoryCache.TryGetValue(key, out value);
        }
    }
}
