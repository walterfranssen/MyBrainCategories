using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyBrainCategories.Application.Infrastructure
{
    [Serializable]
    public class MyBrainValidationException : Exception
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public MyBrainValidationException()
        {
        }

        public MyBrainValidationException(List<ValidationError> lst) : base("Validation Error")
        {
            this.ValidationErrors = lst;
        }

        public MyBrainValidationException(string message) : base(message)
        {
        }

        public MyBrainValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyBrainValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}