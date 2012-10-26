using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Skeletor.Web.UI.Infrastructure.Validation;

namespace Skeletor.Web.UI.Infrastructure.Validation
{
    public class Validator
    {
        private static readonly ICollection<Action<Exception>> _handlers = new List<Action<Exception>>();

        private readonly Func<bool> _operation;

        private Validator(Func<bool> operation)
        {
            _operation = operation;
        }

        public static Validator Validate(Func<bool> operation)
        {
            return new Validator(operation);
        }

        public Validator AddHandler(Action<Exception> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public static void AddDefaultHandler(Action<Exception> handler)
        {
            _handlers.Add(handler);
        }

        public bool Evaluate()
        {
            try
            {
                return _operation();
            }
            catch (Exception e)
            {
                foreach (var handler in _handlers.Where(handler => handler.GetType().GetGenericArguments()[0] == e.GetType()))
                {
                    handler(e);
                    return false;
                }

                throw;
            }
        }
    }
}

