using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class PetDTO
    {
        public int PetId { get; set; }
        public string PetName { get; set; }    
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}
