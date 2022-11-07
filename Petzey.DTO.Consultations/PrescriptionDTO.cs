using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.DTO.Consultations
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public  ICollection<AddMedicineDTO> MedicineDTOs{ get; set; }
        
    }
}
