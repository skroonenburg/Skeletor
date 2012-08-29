using System;

namespace Skeletor.Core.Framework
{
    public class MissingTransactionAttributeException : Exception
    {
         public MissingTransactionAttributeException(string message) : base(message)
         {
         }
    }
}