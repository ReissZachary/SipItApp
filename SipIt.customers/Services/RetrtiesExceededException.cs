using System;
using System.Runtime.Serialization;

namespace SipIt.customers.Services
{
    [Serializable]
    internal class RetrtiesExceededException : Exception
    {
        public RetrtiesExceededException()
        {
        }

        public RetrtiesExceededException(string message) : base(message)
        {
        }

        public RetrtiesExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetrtiesExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}