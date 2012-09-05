using System;
using System.Collections.Generic;

namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class Invocation
    {
        
        public Invocation(string methodName)
        {
            MethodName = methodName;
            Arguments = new List<InvocationArgument>();
        }

        public void AddArg(string name, object value)
        {
            if(String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter name was not supplied or is empty","name");

            Arguments.Add(new InvocationArgument(name,value));
        }

        public string MethodName { get; private set; }
        public IList<InvocationArgument> Arguments { get; private set; }
    }
}