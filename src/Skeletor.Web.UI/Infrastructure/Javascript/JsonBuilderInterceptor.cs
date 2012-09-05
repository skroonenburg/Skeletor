using Castle.DynamicProxy;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class JsonBuilderInterceptor : IInterceptor
    {
        private readonly JsonRecorder recorder;

        public JsonBuilderInterceptor(JsonRecorder recorder)
        {
            this.recorder = recorder;
        }

        public void Intercept(IInvocation invocation)
        {
            recorder.RecordInvocation(invocation);
        }
    }
}