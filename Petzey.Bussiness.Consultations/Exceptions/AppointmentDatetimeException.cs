using System;
using System.Runtime.Serialization;

namespace Petzey.Bussiness.Consultations.Implementations
{
    [Serializable]
    public class AppointmentDatetimeException : Exception
    {
        public AppointmentDatetimeException()
        {
        }

        public AppointmentDatetimeException(string message) : base(message)
        {
        }

        public AppointmentDatetimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

   
    }
}