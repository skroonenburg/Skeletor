using System;

namespace Skeletor.Core.Framework
{
    public class ValidationException : Exception
    {
        public bool HasErrors
        {
            get { return false; }
        }

        public int ErrorCount
        {
            get { return 0; }
        }
    }
}