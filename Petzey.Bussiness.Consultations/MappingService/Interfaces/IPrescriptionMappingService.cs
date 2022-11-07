using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.MappingService.Interfaces
{
    public interface IPrescriptionMappingService
    {
        Prescription ConvertToPrescription(PrescriptionDTO dto);
        ICollection<Medicine> ConvertToListOfMedicine(ICollection<AddMedicineDTO> medicine);
        ICollection<AddMedicineDTO> ConvertToListOfMedicineDTO(ICollection<Medicine> medicine);
        Medicine ConvertToMedicine(AddMedicineDTO medicineDTO);
        PrescriptionDTO ConvertToPrescriptionDTO(Prescription prescription);
        AddMedicineDTO ConvertToMedicineDTO(Medicine medicineDTO);
    }
}
