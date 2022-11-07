using System;
using System.Runtime.Serialization;

namespace Petzey.Bussiness.Consultations.MappingService.Implementations
{
    [Serializable]
    internal class InvalidDataException : Exception
    {
        public InvalidDataException()
        {
        }

        public InvalidDataException(string message) : base(message)
        {
        }

        public InvalidDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}