using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Cake.SqlTools
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ConnectionNullException : Exception
    {
        public ConnectionNullException()
        {
        }

        public ConnectionNullException(string message)
            : base(message)
        {
        }

        public ConnectionNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ConnectionNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
