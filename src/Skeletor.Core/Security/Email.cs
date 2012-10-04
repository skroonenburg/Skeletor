namespace Skeletor.Core.Security
{
    public class Email
    {
        protected Email(){}

        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}