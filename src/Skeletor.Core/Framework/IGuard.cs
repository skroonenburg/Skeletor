using System;
using System.Collections.Generic;

namespace Skeletor.Core.Framework
{
    public interface IGuard
    {
        IGuard Then(Func<bool> predicate, string message);
        IEnumerable<string> EnforceInvariants();
    }
}