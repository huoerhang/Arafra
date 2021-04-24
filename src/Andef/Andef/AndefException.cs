using System;
using System.Runtime.Serialization;

namespace Andef
{
    public class AndefException : Exception
    {
        public AndefException()
        {

        }

        public AndefException(string message) : base(message)
        {

        }

        public AndefException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public AndefException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
