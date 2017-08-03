using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using CQRSDemoApp.Dtos;

namespace CQRSDemoApp
{
    public class MemoryRepository<T>: IRepository<T> where T : IIdentity
    {
        private readonly DateTimeOffset expirationDate = DateTimeOffset.UtcNow.AddMinutes(30);
        public void Add(T obj)
        {
            var key = obj.GetType().FullName;
            var memoryCache = MemoryCache.Default;

            var value = memoryCache.Get(key);
            if (value == null)
            {
                memoryCache.Add(key, new List<T> { obj }, expirationDate);
            }
            else
            {
                var values = (List<T>)value;
                values.Add(obj);
                memoryCache.Remove(key);
                memoryCache.Add(key, values, expirationDate);
            }
        }

        public List<T> GetAll()
        {
            var memoryCache = MemoryCache.Default;
            var key = typeof(T).FullName;
            return (List<T>)memoryCache.Get(key);
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        private string GetKey<T>(Guid id)
        {
            return "";
        }

        public object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }

        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }



    }
}