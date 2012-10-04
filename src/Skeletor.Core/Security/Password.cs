using System;

namespace Skeletor.Core.Security
{
    public class Password
    {
        protected Password(){}

        public Password(string unencodedText, int minLength, int maxLength, DateTime expiryDate)
        {
            Salt = BCrypt.Net.BCrypt.GenerateSalt();
            Text = BCrypt.Net.BCrypt.HashPassword(unencodedText, Salt);
            MinLength = minLength;
            MaxLength = maxLength;
            ExpiryDate = expiryDate;
        }

        public string Text { get; private set; }
        public string Salt { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public DateTime ExpiryDate { get; private set; }
    }
}