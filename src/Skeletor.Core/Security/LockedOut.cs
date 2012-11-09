using System;

namespace Skeletor.Core.Security
{
    public class LockedOut
    {
        public LockedOut()
        {
            IsLockedOut = false;
        }

        public LockedOut(DateTime lockedOutDate)
        {
            LastLockedOutUtcDate = lockedOutDate;
            IsLockedOut = true;
        }

        public DateTime? LastLockedOutUtcDate { get; private set; }
        public bool IsLockedOut { get; private set; }
    }
}