using System;
using System.Runtime.Serialization;

namespace Delof
{
    public class DelofException : Exception
    {
        public DelofException()
        {

        }

        public DelofException(string message) : base(message)
        {

        }

        public DelofException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public DelofException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
