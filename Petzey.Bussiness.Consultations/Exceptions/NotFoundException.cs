using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string message=null, Exception innerException=null) : base(message, innerException)
        {
        }
    }
}
