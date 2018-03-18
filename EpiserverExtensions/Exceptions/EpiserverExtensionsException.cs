using System;

namespace EpiserverExtensions.Exceptions
{
    public class EpiserverExtensionsException : Exception
    {
        public EpiserverExtensionsException() : base()
        {
        }

        public EpiserverExtensionsException(string message) : base(message)
        {
        }

        public EpiserverExtensionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EpiserverExtensionsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
