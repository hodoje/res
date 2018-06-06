using DataAccess;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy
{
    public class CacheManager<T> : ICacheManager<T> where T : class
    {
        public ObjectCache CachedData
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public void Clear()
        {
            foreach (var item in CachedData)
            {
                Remove(item.Key);
            }
        }

        public T Get(string key)
        {
            return (T)CachedData[key];
        }

        public bool IsSet(string key)
        {
            return CachedData.Contains(key);
        }

        public void Remove(string key)
        {
            CachedData.Remove(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromHours(cacheTime)
            };

            CachedData.Add(new CacheItem(key, data), policy);
        }

    }
}
