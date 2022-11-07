using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class AppointmentCardDTO
    {
        public int AppointmentId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string Gender { get; set; }
        public string OwnerName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public DateTime PetDOB { get; set; }
        public int VetId { get; set; }
        public string VetName { get; set; }
        public string VetSpeciality { get; set; }

    }
}
