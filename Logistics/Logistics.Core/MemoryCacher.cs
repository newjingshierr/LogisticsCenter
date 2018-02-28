using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Core
{
    public class MemoryCacher
    {


        public static T GetValue<T>(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return (T)memoryCache.Get(key);
        }

        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);

        }

        public static bool set(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            try
            {
                memoryCache.Set(key, value, absExpiration);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }

        public static bool Delete(string key)
        {
            try
            {
                MemoryCache memoryCache = MemoryCache.Default;
                if (memoryCache.Contains(key))
                {
                    memoryCache.Remove(key);
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


    }
}
