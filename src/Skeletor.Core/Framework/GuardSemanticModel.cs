using System.Collections.Generic;

namespace Skeletor.Core.Framework
{
    public class GuardSemanticModel
    {
        public GuardSemanticModel()
        {
            Invariants = new List<Invariant>();
        }

        public void Add(Invariant invariant)
        {
            Invariants.Add(invariant);
        }

        public ICollection<Invariant> Invariants { get; private set; }
    }
}