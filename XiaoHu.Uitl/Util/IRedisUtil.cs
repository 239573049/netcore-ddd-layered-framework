using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Uitl.Util
{
    public interface IRedisUtil
    {
        string Get(string key);
        void Set(string key, object t, DateTime expiresSec);
        T Get<T>(string key) where T : new();
        Task<string> GetAsync(string key);
        Task SetAsync(string key,object t,DateTime expiresSec);
        Task<T> GetAsync<T>(string key) where T: new();
        bool SetDate(string key,DateTime date);
        Task<bool> SetDateAsync(string key,DateTime date);
    }
}
