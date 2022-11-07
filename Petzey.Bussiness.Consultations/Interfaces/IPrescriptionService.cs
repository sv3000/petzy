using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.Interfaces
{
    public interface IPrescriptionService
    {
        PrescriptionDTO AddPrescription(PrescriptionDTO prescription, int appointmentId);
        AddMedicineDTO AddMedicine(AddMedicineDTO medicine);
        PrescriptionDTO EditPrescription(PrescriptionDTO prescription);
        AddMedicineDTO GetMedicine(int Id);
        ICollection<AddMedicineDTO> GetAllMedicinesByPrescription(int prescriptionId);
    }
}
