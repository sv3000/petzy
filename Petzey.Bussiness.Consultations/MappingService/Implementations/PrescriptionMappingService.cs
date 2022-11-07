using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.MappingService.Implementations
{
    public class PrescriptionMappingService : IPrescriptionMappingService
    {
        public Prescription ConvertToPrescription(PrescriptionDTO dto)
        {
            Prescription prescription = new Prescription
            {
                Id = dto.Id,
                Medicines = ConvertToListOfMedicine(dto.MedicineDTOs),

            };
            return prescription;
        }
        public PrescriptionDTO ConvertToPrescriptionDTO(Prescription prescription)
        {
            return new PrescriptionDTO
            {
                Id = prescription.Id,
                MedicineDTOs = ConvertToListOfMedicineDTO(prescription.Medicines)
            };
        }

        public ICollection<Medicine> ConvertToListOfMedicine(ICollection<AddMedicineDTO> medicine)
        {
            ICollection<Medicine> result = new List<Medicine>();
            foreach (var med in medicine)
            {
                result.Add(ConvertToMedicine(med));
            }
            return result;
        }
        public ICollection<AddMedicineDTO> ConvertToListOfMedicineDTO(ICollection<Medicine> medicine)
        {
            ICollection<AddMedicineDTO> result = new List<AddMedicineDTO>();
            foreach (var med in medicine)
            {
                result.Add(ConvertToMedicineDTO(med));
            }
            return result;
        }
        public Medicine ConvertToMedicine(AddMedicineDTO medicineDTO)
        {
            Medicine medicine = new Medicine
            {
                Intake = medicineDTO.Intake.ToLower() == "beforefood" ? IntakeDTO.BEFOREFOOD : IntakeDTO.AFTERFOOD,
                Span = medicineDTO.Days,
                MedicineName = medicineDTO.MedicineName,
                AdditionalComment = medicineDTO.AdditionalComments,
                Id = medicineDTO.MedicineId,
                PrescriptionId = medicineDTO.PrescriptionId
            };
            if (medicineDTO.TimeOfDay.ToLower() == "morning")
            {
                medicine.TimeOfDay = TimeOfDay.MORNING;
            }
            else if(medicineDTO.TimeOfDay.ToLower() == "afternoon")
            {
                medicine.TimeOfDay = TimeOfDay.AFTERNOON;
            }
            else if (medicineDTO.TimeOfDay.ToLower() == "evening")
            {
                medicine.TimeOfDay = TimeOfDay.EVENING;
            }
            else
            {
                throw new InvalidDataException("Given Time Of Day is not valid");
            }
            return medicine;
        }
        public AddMedicineDTO ConvertToMedicineDTO(Medicine medicineD)
        {
            return new AddMedicineDTO
            {
                Intake = medicineD.Intake.ToString(),
                AdditionalComments = medicineD.AdditionalComment,
                Days = medicineD.Span,
                MedicineId = medicineD.Id,
                MedicineName = medicineD.MedicineName,
                TimeOfDay =  medicineD.TimeOfDay.ToString(),
                PrescriptionId = medicineD.PrescriptionId
            };
        }



    }
}
