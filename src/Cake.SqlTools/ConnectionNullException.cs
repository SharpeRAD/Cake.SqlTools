namespace Cake.SqlTools
{
#if !NET8_0_OR_GREATER
    [Serializable]
#endif
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

#if !NET8_0_OR_GREATER
        protected ConnectionNullException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
