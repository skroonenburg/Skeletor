using System;
using System.Data;

namespace Skeletor.Core.Framework
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TransactionAttribute : Attribute
    {

        public TransactionAttribute(string message, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            Message = message;
            IsolationLevel = isolationLevel;
        }

        public string Message { get; private set; }
        public IsolationLevel IsolationLevel { get; private set; }
    }
}