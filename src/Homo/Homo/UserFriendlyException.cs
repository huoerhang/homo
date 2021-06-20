﻿using System;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace Homo
{
    [Serializable]
    public class UserFriendlyException : BusinessException
    {
        public UserFriendlyException(string message, string code = null, string details = null, Exception innerException = null, LogLevel logLevel = LogLevel.Information)
            : base(code, message, details, innerException, logLevel)
        {
        }

        public UserFriendlyException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
