using System;

namespace Skeletor.Core.Framework
{
    public interface IAuditable
    {
        DateTime CreatedOnUtc { get; }
        DateTime? ModifiedOnUtc { get; }
        Guid CreatedBy { get; }
        Guid? ModifiedBy { get; }
    }
}