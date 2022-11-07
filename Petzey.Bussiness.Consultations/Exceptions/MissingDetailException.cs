using System;
using System.Runtime.Serialization;

namespace Petzey.Bussiness.Consultations.Implementations
{
    [Serializable]
    public class MissingDetailException : Exception
    {
        public MissingDetailException()
        {
        }

        public MissingDetailException(string message) : base(message)
        {
        }

        public MissingDetailException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}