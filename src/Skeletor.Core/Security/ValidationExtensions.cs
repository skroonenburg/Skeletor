using System.Collections.Generic;
using System.Linq;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public static class ValidationExtensions
    {
        public static void ThrowIfAny(this IEnumerable<string> messages)
        {
            if (messages == null) return;
            if (!messages.Any()) return;

            var exception = new ValidationException();

            foreach (var message in messages)
                exception.AddError(message);

            throw exception;
        }
    }
}