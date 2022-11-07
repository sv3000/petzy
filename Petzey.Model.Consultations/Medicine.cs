using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Model.Consultations
{
    public class Medicine
    {
        public int Id { get; set; }
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string MedicineName { get; set; }
        public IntakeDTO Intake { get; set; }
        public int Span { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public string AdditionalComment { get; set; }
    }
}
