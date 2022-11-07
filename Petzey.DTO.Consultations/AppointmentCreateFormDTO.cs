using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class AppointmentCreateFormDTO
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Issue { get; set; }
        public string Reason { get; set; }
        public PetParentDTO Parent { get; set; }
        public PetDTO Pet { get; set; }   
        public VetDTO Vet { get; set; }        
    }
}
