using System;
using System.Collections.Generic;

namespace Skeletor.Core.Framework
{
    public class ValidationException : Exception
    {

        public ValidationException()
        {
            Errors = new List<ValidationError>();
        }

        public bool HasErrors
        {
            get { return Errors.Count > 0; }
        }

        public int ErrorCount
        {
            get { return Errors.Count; }
        }

        public void AddError(string errorMessage)
        {
            Errors.Add(new ValidationError(errorMessage));
        }

        public IList<ValidationError> Errors { get; private set; }
    }
}