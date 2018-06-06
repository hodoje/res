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
        public ObjectCache CachedData => MemoryCache.Default;

        public void Clear()
        {
            foreach (var item in CachedData)
            {
                Remove(item.Key);
            }
        }

        public T Get(string key)
        {
            T entity = null;
            if (!String.IsNullOrEmpty(key))
            {
                entity = (T)CachedData[key];
            }
            return entity;
        }

        public bool IsSet(string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                return CachedData.Contains(key);
            }
            return false;
        }

        public void Remove(string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                CachedData.Remove(key);
            }
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data != null && !String.IsNullOrEmpty(key))
            {
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now + TimeSpan.FromHours(cacheTime)
                };

                CachedData.Add(new CacheItem(key, data), policy);
            }
        }

    }
}
