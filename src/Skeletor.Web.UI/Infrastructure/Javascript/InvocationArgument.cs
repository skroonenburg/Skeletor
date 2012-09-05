namespace Skeletor.Web.UI.Infrastructure.Javascript
{
    public class InvocationArgument
    {
        

        public InvocationArgument(string argName) : this(argName,null)
        {
        }

        public InvocationArgument(string argName, object value)
        {
            ArgName = argName;
            Value = value;
        }

        public string ArgName { get; private set; }
        public object Value { get; set; }
    }
}