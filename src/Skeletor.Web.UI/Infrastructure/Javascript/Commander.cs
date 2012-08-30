using System;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{

    public interface IHandleCommands
    {
    }

    public interface IJQueryCommands : IHandleCommands
    {
        void Html(string element, string html);
        void Text(string element, string text);
    }


    public class JsonRecorder
    {

    }

    public interface IJsonCommandGenerator<T> where T : class, IHandleCommands
    {
        JsonCommandGenerator<T> For(Action<T> action) ;
        JsonRecorder Execute();
    }


    public static class JsonInterfaceGenerator
    {
        public static ProxyGenerator Generator { get; private set; }

        static JsonInterfaceGenerator()
        {
            Generator = new ProxyGenerator();
        }

        public static T GenerateProxy<T>(JsonRecorder recorder) where T : class, IHandleCommands
        {
            return Generator.CreateInterfaceProxyWithoutTarget<T>(new JsonBuilderInterceptor(recorder));
        }
    }

    public class JsonBuilderInterceptor : IInterceptor
    {
        private readonly JsonRecorder recorder;

        public JsonBuilderInterceptor(JsonRecorder recorder)
        {
            this.recorder = recorder;
        }

        public void Intercept(IInvocation invocation)
        {
            
        }
    }

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

    public class JsonCommandGenerator<T> : IJsonCommandGenerator<T> where T : class, IHandleCommands
    {

        private readonly JsonRecorder recorder;
        private ProxyCache cache;

        public JsonCommandGenerator()
        {
            recorder = new JsonRecorder();
            cache = new ProxyCache();
        }

        public JsonCommandGenerator<T> For(Action<T> action)
        {

            T proxy = null;

            if(!cache.ContainsProxyObjectFor<T>())
            {
                proxy = JsonInterfaceGenerator.GenerateProxy<T>(recorder);
                cache.StoreProxy<T>(proxy);
            }else
            {
                proxy = cache.GetProxy<T>();
            }

            action(proxy);
             
            return this;
        }

        public JsonRecorder Execute()
        {
            return recorder;
        }
    }
}