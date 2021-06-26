using System;
using System.Runtime.Serialization;

namespace Homo
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string code = null, string messsage = null, string details = null, Exception innerException = null)
            : base(messsage, innerException)
        {
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
