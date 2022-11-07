using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Model.Consultations
{
    public class Appointment
    {
        public Appointment()
        {
            Status = AppointmentStatus.OPEN;
            Test = new HashSet<Test>();
            Vital = new Vital();
            Symptom = new HashSet<Symptom>();
            PetParent = new PetParent();
            CreatedAt = DateTime.Now;
            AppointmentDate = DateTime.Now;
            Prescription = new Prescription();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="Date")]
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public Vet VetDetails { get; set; }
        public PetParent PetParent { get; set; }
        public  Pet Pet { get; set; }
        public string Issue { get; set; }
        public string Comment { get; set; }
        public string Reason { get; set; }
        public Prescription Prescription { get; set; }
        public Vital Vital { get; set; }
        public ICollection<Symptom> Symptom { get; set; }
        public ICollection<Test> Test { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreatedAt { get; private set; }
    }

    
    
}
