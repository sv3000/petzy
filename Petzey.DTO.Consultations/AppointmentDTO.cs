using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatusDTO Status { get; set; }
        public string Issue { get; set; }
        public string Comment { get; set; }
        public string Reason { get; set; }
        public PrescriptionDTO Prescription { get; set; }
        public PetDTO Pet { get; set; }
        public VetDTO Vet { get; set; }
        public PetParentDTO PetParent { get; set; }
        public VitalDTO Vital { get; set; }
        public ICollection<SymptomDTO> Symptom { get; set; }
        public ICollection<TestDTO> Test { get; set; }
    }
}
