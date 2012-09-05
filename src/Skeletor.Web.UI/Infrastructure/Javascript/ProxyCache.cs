using System;
using System.Collections.Generic;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class ProxyCache
    {
        private Dictionary<Type, object> proxies;

        public ProxyCache()
        {
            proxies = new Dictionary<Type, object>();
        }

        public bool ContainsProxyObjectFor<T>() where T : class, IHandleCommands
        {
            return proxies.ContainsKey(typeof(T));
        }

        public void StoreProxy<T>(T proxy) where T : class, IHandleCommands
        {
            proxies.Add(typeof(T), proxy);
        }

        public T GetProxy<T>() where T : class, IHandleCommands
        {
            return (T) proxies[typeof (T)];
        }
    }
}