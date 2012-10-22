using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class Username
    {
        protected Username(){}

        public Username(string text)
        {
            Guard.On(() => !string.IsNullOrWhiteSpace(text),"Username is required")
                 .EnforceInvariants()
                 .ThrowIfAny();
            Name = text;
        }

        public string Name { get; private set; }
    }
}