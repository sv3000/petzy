using Petzey.Bussiness.Consultations.Interfaces;
using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using Petzey.Repository.Consultations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.Implementations
{
    public class PrescriptionService:IPrescriptionService
    {
        private IPrescriptionRepository repo;
        private IPrescriptionMappingService service;
        public PrescriptionService(IPrescriptionRepository repo, IPrescriptionMappingService service)
        {
            this.repo = repo;
            this.service = service;
        }

        public PrescriptionDTO AddPrescription(PrescriptionDTO prescription , int appointmentId)
        {
            Prescription p = repo.AddPrescription(service.ConvertToPrescription(prescription), appointmentId);
            return service.ConvertToPrescriptionDTO(p);
        }

        public AddMedicineDTO AddMedicine(AddMedicineDTO medicine)
        {
            Medicine m = repo.AddMedicine(service.ConvertToMedicine(medicine));
            return service.ConvertToMedicineDTO(m);
        }

        public PrescriptionDTO EditPrescription(PrescriptionDTO prescription)
        {
            Prescription p = repo.EditPrescription(service.ConvertToPrescription(prescription));
            return service.ConvertToPrescriptionDTO (p);
        }
        
        public AddMedicineDTO GetMedicine(int Id)
        {
            Medicine m = repo.GetMedicine(Id);
            return service.ConvertToMedicineDTO (m);
        }

        public ICollection<AddMedicineDTO> GetAllMedicinesByPrescription(int prescriptionId)
        {
            ICollection<Medicine> result = repo.GetAllMedicinesByPrescriptionId(prescriptionId);
            return service.ConvertToListOfMedicineDTO(result);
        }
    }
}
