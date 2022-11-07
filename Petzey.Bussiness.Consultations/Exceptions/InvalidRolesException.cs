using System;
using System.Runtime.Serialization;

namespace Petzey.Bussiness.Consultations.Implementations
{
    [Serializable]
    public class InvalidRolesException : ApplicationException
    {
       

        public InvalidRolesException(string message=null, Exception innerException=null) : base(message, innerException)
        {
        }

       
    }
}