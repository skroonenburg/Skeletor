using System;
using System.Collections.Generic;
using System.Linq;

namespace Skeletor.Core.Framework
{
    public class Guard : IGuard
    {

        public static IGuard On(Func<bool> predicate, string message)
        {
            return new Guard(predicate, message);
        }

        public static IGuard Combine(params IGuard[] others)
        {

            var g = new Guard();

            foreach (var guard in others)
            {
                g.AddOtherInvariants(((Guard)guard).model);
            }

            return g;
        }

        private void AddOtherInvariants(GuardSemanticModel otherModel)
        {
            foreach(var i in otherModel.Invariants)
            {
                model.Add(i);
            }
        }

        private Guard()
        {
            model = new GuardSemanticModel();
        }

        private Guard(Func<bool> predicate, string message)
            : this()
        {
            model.Add(new Invariant(predicate, message));
        }

        public IGuard Then(Func<bool> predicate, string message)
        {
            model.Add(new Invariant(predicate, message));
            return this;
        }

        public IEnumerable<string> EnforceInvariants()
        {
            return model.Invariants.Where(x => x != null).Select(invariant => invariant.ValidationError());
        }

        private GuardSemanticModel model;
    }
}