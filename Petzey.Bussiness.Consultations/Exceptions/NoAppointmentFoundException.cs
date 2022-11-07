using System;
using System.Runtime.Serialization;

namespace Petzey.Bussiness.Consultations.Implementations
{
    [Serializable]
    public class NoAppointmentFoundException : Exception
    {
     
     
        public NoAppointmentFoundException(string message=null, Exception innerException=null) : base(message, innerException)
        {
        }

       
    }
}