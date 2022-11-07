using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Repository.Consultations.Interfaces
{
    public interface IPrescriptionRepository
    {
        ICollection<Medicine> GetAllMedicinesByPrescriptionId(int PrescriptionId);
        Medicine GetMedicine(int Id);
        Prescription EditPrescription(Prescription prescription);
        Medicine AddMedicine(Medicine medicine);
        Prescription AddPrescription(Prescription prescription, int appointmentId);
    }
}
