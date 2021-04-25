using System;
using System.Runtime.Serialization;
using Delof.ExceptionHandling;
using Delof.Logging;
using Microsoft.Extensions.Logging;

namespace Delof
{
    [Serializable]
    public class BusinessException : DelofException, IHasErrorCode, IHasErrorDetails, IHasLogLevel
    {
        public string Code { get; set; }

        public string Details { get; set; }

        public LogLevel LogLevel { get; set; }

        public BusinessException(string code=null,string messsage=null,string details=null,Exception innserException=null,LogLevel logLevel=LogLevel.Warning)
            : base(messsage, innserException)
        {
            Code = code;
            Details = details;
            LogLevel = logLevel;
        }

        public BusinessException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        }

        public BusinessException WithData(string name, object value)
        {
            Data[name] = value;
            return this;
        }
    }
}
