

using System;
using ServiceStack.Redis;

namespace Public.Cache.Redis
{
    public interface ICache
    {
        bool Set<T>(string segment, string key, T obj, DateTime expiry);
        T Get<T>(string segment, string key);
        bool Remove(string segment, string key);
        bool Exists(string key);
        bool IsOk();
    };

    public class Cache : ICache
    {
        private static PooledRedisClientManager _mRedisClientManager;
        private static readonly Cache MCache = new Cache();

        private Cache()
        {
        }

        public static Cache Instance
        {
            get { return MCache; }
        }

        public bool Exists(string key)
        {
            return false;
        }

        public bool IsOk()
        {
            return _mRedisClientManager != null;
        }

        /// <summary>
        /// </summary>
        /// <param name="segment">应用段名</param>
        /// <param name="key"></param>
        public bool Remove(string segment, string key)
        {
            return _mRedisClientManager.Remove(segment + ":" + key);
        }

        /// <summary>
        ///     设置键值，如键不存在自动创建
        /// </summary>
        /// <param name="segment">应用段名</param>
        /// <param name="key"> 键名 </param>
        /// <param name="obj">键值,非基本类型须标识为可序列化对象</param>
        /// <param name="expiry"></param>
        public bool Set<T>(string segment, string key, T obj, DateTime expiry)
        {
            return _mRedisClientManager.Set(segment + ":" + key, obj, expiry);
        }

        /// <summary>
        ///     作用：根据Key得到缓存中的数据
        /// </summary>
        /// <param name="segment">应用段名</param>
        /// <param name="key">缓存中的对象名称</param>
        /// <returns></returns>
        public T Get<T>(string segment, string key)
        {
            return _mRedisClientManager.Get<T>(segment + ":" + key);
        }

        /// <summary>
        ///     缓存服务器初始化，在启动中执行
        /// </summary>
        public static void Init(String[] serverlist)
        {
            if (_mRedisClientManager != null) return;
            if (serverlist == null || serverlist.Length < 1) return;

            _mRedisClientManager = new PooledRedisClientManager(serverlist);
        }

        public static bool Replace<T>(string segment, string key, T obj, DateTime expiry)
        {
            return _mRedisClientManager.Replace(segment + ":" + key, obj, expiry);
        }

        /// <summary>
        ///     重命名键
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="key"></param>
        /// <param name="newkey"></param>
        /// <returns></returns>
        public static bool RenameKey(string segment, string key, string newkey)
        {
            using (var client = _mRedisClientManager.GetCacheClient() as RedisClient)
            {
                if (client == null)
                {
                    return false;
                }

                client.RenameKey(segment + ":" + key, segment + ":" + newkey);
                return true;
            }
        }
    }
}