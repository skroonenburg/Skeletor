using Castle.DynamicProxy;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
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
}