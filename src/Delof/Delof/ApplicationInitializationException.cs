using System;
using System.Runtime.Serialization;

namespace Delof
{
    public class ApplicationInitializationException : DelofException
    {
        public ApplicationInitializationException()
        {

        }

        public ApplicationInitializationException(string message)
            : base(message)
        {

        }

        public ApplicationInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public ApplicationInitializationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
