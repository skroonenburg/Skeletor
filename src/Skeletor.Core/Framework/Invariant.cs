using System;
using System.Collections.Generic;
using System.Linq;

namespace Skeletor.Core.Framework
{
    public class Invariant
    {

        public Invariant(Func<bool> predicate, string message)
        {
            Predicate = predicate;
            Message = message;
        }

        public Func<bool> Predicate { get; private set; }
        public string Message { get; private set; }

        public string ValidationError()
        {
            return !Predicate() ? Message : null;
        }
    }
}