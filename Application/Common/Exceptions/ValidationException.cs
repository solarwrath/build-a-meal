using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
            : this()
        {
            Errors = validationFailures
                .GroupBy(
                    validationFailure => validationFailure.PropertyName,
                    validationFailure => validationFailure.ErrorMessage
                )
                .ToDictionary(
                    failureGroup => failureGroup.Key,
                    failureGroup => failureGroup.ToArray()
                );
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}