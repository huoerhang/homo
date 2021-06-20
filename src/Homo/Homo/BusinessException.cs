using System;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace Homo
{
    [Serializable]
    public class BusinessException : Exception, IHasErrorCode, IHasErrorDetails, IHasLogLevel
    {
        public string Code { get; set; }

        public string Details { get; set; }

        public LogLevel LogLevel { get; set; }

        public BusinessException(string code = null, string messsage = null, string details = null, Exception innerException = null, LogLevel logLevel = LogLevel.Warning)
            : base(messsage, innerException)
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
