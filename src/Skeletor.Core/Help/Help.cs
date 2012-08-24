using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Help
{
    public class Help : Aggregate<Guid>
    {

        public Help(string subject, string description, string url)
        {

            Validate(subject, description, url);

            Subject = subject;
            Description = description;
            Url = url;
        }

        public void ChangeHelp(string subject, string description, string url)
        {
            
        }

        private void Validate(string subject, string description, string url)
        {
            
        }
        

        public string Subject { get; private set; }
        public string Url { get; private set; }
        public string Description { get; private set; }
    }
}