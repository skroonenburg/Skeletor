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
            LockedOutDate = lockedOutDate;
            IsLockedOut = true;
        }

        public DateTime? LockedOutDate { get; private set; }
        public bool IsLockedOut { get; private set; }
    }
}