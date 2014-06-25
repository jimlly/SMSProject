

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
        /// <param name="segment">Ӧ�ö���</param>
        /// <param name="key"></param>
        public bool Remove(string segment, string key)
        {
            return _mRedisClientManager.Remove(segment + ":" + key);
        }

        /// <summary>
        ///     ���ü�ֵ������������Զ�����
        /// </summary>
        /// <param name="segment">Ӧ�ö���</param>
        /// <param name="key"> ���� </param>
        /// <param name="obj">��ֵ,�ǻ����������ʶΪ�����л�����</param>
        /// <param name="expiry"></param>
        public bool Set<T>(string segment, string key, T obj, DateTime expiry)
        {
            return _mRedisClientManager.Set(segment + ":" + key, obj, expiry);
        }

        /// <summary>
        ///     ���ã�����Key�õ������е�����
        /// </summary>
        /// <param name="segment">Ӧ�ö���</param>
        /// <param name="key">�����еĶ�������</param>
        /// <returns></returns>
        public T Get<T>(string segment, string key)
        {
            return _mRedisClientManager.Get<T>(segment + ":" + key);
        }

        /// <summary>
        ///     �����������ʼ������������ִ��
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
        ///     ��������
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