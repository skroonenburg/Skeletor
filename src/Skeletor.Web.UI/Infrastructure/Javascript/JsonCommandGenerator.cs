using System;
using Newtonsoft.Json;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class JsonCommandGenerator<T> : IJsonCommandGenerator<T> where T : class, IHandleCommands
    {

        private readonly JsonRecorder recorder;
        private readonly ProxyCache cache;

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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(recorder);
        }
    }
}