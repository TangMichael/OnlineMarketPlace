using System;
using System.Runtime.Serialization;

namespace OnlineMarketPlace.Repository
{
    [Serializable]
    internal class EmptyProductException : Exception
    {
        public EmptyProductException()
        {
        }

        public EmptyProductException(string message) : base(message)
        {
        }

        public EmptyProductException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}