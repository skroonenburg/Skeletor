using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class JsonRecorder
    {

        public JsonRecorder()
        {
            Invocations = new List<Invocation>();
        }

        public void RecordInvocation(IInvocation invocation)
        {
            var item = new Invocation(invocation.MethodInvocationTarget.Name);
            if (HasArguments(invocation))
                RecordArgs(item, invocation);
            Invocations.Add(item);
        }

        private static bool HasArguments(IInvocation invocation)
        {
            return invocation.MethodInvocationTarget.GetParameters().Any();
        }

        private void RecordArgs(Invocation item, IInvocation invocation)
        {
            foreach(var arg in invocation.MethodInvocationTarget.GetParameters())
            {
                item.AddArg(arg.Name, invocation.GetArgumentValue(arg.Position));
            }
        }

        public IList<Invocation> Invocations { get; private set; }
    }
}