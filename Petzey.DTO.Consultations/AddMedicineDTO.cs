using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class AddMedicineDTO
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public int Days { get; set; }
        public string Intake { get; set; }
        public string TimeOfDay { get; set; }
        public string AdditionalComments { get; set; }
    }
}
