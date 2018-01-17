using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logistics.Core
{
    public class MemCached
    {
        private static MemcachedClient mclient;
        static readonly object padlock = new object();
        public static MemcachedClient getInstance()
        {
            if (mclient == null)
            {
                lock (padlock)
                {
                    if (mclient == null)
                    {
                        MemClientInit();
                    }
                }
            }
            return mclient;
        }
        static void MemClientInit()
        {
            //初始化缓存  
            var config = new MemcachedClientConfiguration();
            IPAddress ipAddress = IPAddress.Parse("120.26.164.165");
            config.Servers.Add(new IPEndPoint(ipAddress, 11211));
            config.Protocol = MemcachedProtocol.Binary;
            mclient = new MemcachedClient(config);
        }
    }


    public class MemcachedHelper
    {

        /// <summary>  
        /// 定义一个静态MemcachedClient客户端,它随类一起加载，所有对象共用  
        /// </summary>  
        private static MemcachedClient mclient;
        /// <summary>  
        /// 静态构造函数，初始化Memcached客户端  
        /// </summary>  
         static MemcachedHelper()
        {
            mclient = MemCached.getInstance();
        }
     
        public static bool SetValue<T>(string groupName, string key, T value, DateTime expiry)
        {

            if (value.GetType() == typeof(String))
            {
                return Set(groupName, key, value, expiry);
            }
            else
            {
                return Set(groupName, key, SerializationService.SerializationToJson(value), expiry);
            }
        }
        /// <summary>  
        /// 向Memcached缓存中添加一条数据  
        /// </summary>  
        /// <param name="groupName">组名，用来区分不同的服务或应用场景</param>  
        /// <param name="key">键</param>  
        /// <param name="value">值</param>  
        /// <param name="expiry">过期时间</param>  
        /// <returns>返回是否添加成功</returns>  
        public static bool Set(string groupName, string key, object value, DateTime expiry)
        {
            key = groupName + "-" + key;

            return mclient.Store(StoreMode.Set, key, value, expiry);
        }
        /// <summary>  
        /// 向Memcached缓存中添加一条数据 默认超时24小时  
        /// </summary>  
        /// <param name="groupName">组名，用来区分不同的服务或应用场景</param>  
        /// <param name="key"></param>  
        /// <param name="value"></param>  
        /// <returns></returns>  
        public bool SetValue(string groupName, string key, object value)
        {
            key = groupName + "-" + key;
            return mclient.Store(StoreMode.Set, key, value, DateTime.Now.AddHours(24));
        }
        /// <summary>  
        /// 通过key 来得到一个对象  
        /// </summary>  
        /// <param name="groupName">组名，用来区分不同的服务或应用场景</param>  
        /// <param name="key">键</param>  
        /// <returns>对象</returns>  
        public static object Get(string groupName, string key)
        {
            key = groupName + "-" + key;
            return mclient.Get(key);
        }

        public static object Get(string key)
        {
            return mclient.Get(key);
        }

        /// <summary>  
        /// 通过key 来得到一个对象(前类型)  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="groupName">组名，用来区分不同的服务或应用场景</param>  
        /// <param name="key">键</param>  
        /// <returns></returns>  
        public static T  GetValue<T>(string groupName, string key)
        {
            var o = Get(groupName, key);
            if (o == null)
            {
                return default(T);
            }
            //return mclient.Get<T>(key);
            return SerializationService.DeserializeJsonTo<T>(o.ToString());
        }
        /// <summary>  
        /// 清除指定key的cache  
        /// </summary>  
        /// <param name="groupName">组名，用来区分不同的服务或应用场景</param>  
        /// <param name="key">键</param>  
        /// <returns></returns>  
        public static bool Remove(string groupName, string key)
        {
            key = groupName + "-" + key;
            return mclient.Remove(key);
        }

        public static bool Remove(string key)
        {
            return mclient.Remove(key);
        }
        /// <summary>  
        /// 清除所有cache  
        /// </summary>  
        public static void RemoveAll()
        {
            mclient.FlushAll();
        }
        public static Task<T> GetAsync<T>(String key)
        {
            var tcs = new TaskCompletionSource<T>();
            Task.Factory.StartNew(() => tcs.TrySetResult(Get<T>(key)));
            return tcs.Task;
        }

        public static T Get<T>(string key)
        {
            var value = mclient.Get(key) + "";
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }
            else
            {
                return SerializationService.DeserializeJsonTo<T>(value);
            }
        }


        public static Task<T> GetOrSet<T>(string key, Func<T> func, DateTime expiresAt)
        {
            return GetAsync<T>(key).ContinueWith<T>(d =>
            {
                if (d.Result == null)
                {
                    var rs = func.Invoke();
                    if (rs != null)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Store<T>(StoreMode.Set, key, rs, expiresAt);
                        });
                    }
                    return rs;
                }
                else
                {
                    return d.Result;
                }
            });
        }

        public static bool Store<T>(StoreMode mode, string key, T value, DateTime expiresAt)
        {
            if (value.GetType() == typeof(String))
            {
                return mclient.Store(mode, key, value, expiresAt);
            }
            else
            {
                return mclient.Store(mode, key, SerializationService.SerializationToJson(value), expiresAt);
            }
        }
    }
}
