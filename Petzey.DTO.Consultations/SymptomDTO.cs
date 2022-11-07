using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class SymptomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AppointmentId { get; set; } 
    }
}
