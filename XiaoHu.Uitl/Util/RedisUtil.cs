using Cx.NetCoreUtils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoHu.Uitl.Util
{
    public class RedisUtil : IRedisUtil
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        public T Get<T>(string key) where T : new()
        {
            return RedisHelper.Get<T>(key);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="expiresSec"></param>
        public void Set(string key, object t, DateTime expiresSec)
        {
            RedisHelper.Set(key, t);
            SetDate(key, expiresSec);
        }

        /// <summary>
        /// 异步获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string key)
        {
            return await RedisHelper.GetAsync(key);
        }

        /// <summary>
        /// 获取值泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string key) where T : new()
        {
            return await RedisHelper.GetAsync<T>(key);
        }

        /// <summary>
        /// 修改或新增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="expiresSec"></param>
        /// <returns></returns>
        public async Task SetAsync(string key, object t, DateTime expiresSec)
        {
            await RedisHelper.SetAsync(key, t);
            await SetDateAsync(key, expiresSec);
        }

        /// <summary>
        /// 设置超时时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool SetDate(string key, DateTime date)
        {
            return RedisHelper.PExpireAt(key, date);
        }

        /// <summary>
        /// 设置超时时间异步
        /// </summary>
        /// <param name="key"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Task<bool> SetDateAsync(string key, DateTime date)
        {
            return RedisHelper.PExpireAtAsync(key, date);
        }
    }
}