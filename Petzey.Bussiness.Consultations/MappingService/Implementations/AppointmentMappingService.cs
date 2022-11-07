using Petzey.Bussiness.Consultations.MappingService.Interfaces;
using Petzey.DTO.Consultations;
using Petzey.Model.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Bussiness.Consultations.MappingService
{
    public class AppointmentMappingService:IAppointmentMappingService
    {
        IPrescriptionMappingService prescriptionMappingService;
        public AppointmentMappingService(IPrescriptionMappingService prescriptionMappingService)
        {
            this.prescriptionMappingService = prescriptionMappingService;
        }

        public  Appointment ConvertToAppointment(AppointmentCreateFormDTO dto)
        {
            Appointment appointment = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                Issue = dto.Issue,
                Reason = dto.Reason,
                Pet = ConvertToPet(dto.Pet),
                VetDetails = ConvertToVet(dto.Vet),
                PetParent = ConvertToPetparent(dto.Parent)
            };
            return appointment;
        }

        public AppointmentDTO ConvertToAppointmentDTO(Appointment appointment)
        {
            return new AppointmentDTO
            {
                AppointmentDate = appointment.AppointmentDate,
                Symptom = ConvertToListSymptomDTO(appointment.Symptom),
                Status = new AppointmentStatusDTO
                {
                    AppointmentId = appointment.Id,
                    Status = appointment.Status.ToString(),
                },
                AppointmentId = appointment.Id,
                AppointmentTime = appointment.AppointmentTime,
                Comment = appointment.Comment,
                Issue = appointment.Issue,

                Prescription = new PrescriptionDTO
                {
                    Id = appointment.Prescription.Id,
                    MedicineDTOs = prescriptionMappingService.ConvertToListOfMedicineDTO(appointment.Prescription.Medicines),
                },
                Reason = appointment.Reason,
                Test = ConvertToListTestDTO(appointment.Test),
                Vital = new VitalDTO
                {
                    Ecg = appointment.Vital.ECG,
                    Id = appointment.Vital.Id,
                    Respiration_rate = appointment.Vital.RespirationRate,
                    Temperature = appointment.Vital.Temperature
                },
                Pet = new PetDTO
                {
                    DOB = appointment.Pet.DOB,
                    Gender = appointment.Pet.Gender.ToString(),
                    PetId = appointment.Pet.Id,
                    PetName = appointment.Pet.PetName
                },
                Vet = new VetDTO
                {
                    PhoneNo = appointment.VetDetails.PhoneNo,
                    VetId = appointment.VetDetails.VetId,
                    Speciality = appointment.VetDetails.Speciality,
                    VetName = appointment.VetDetails.Name
                },
                PetParent = new PetParentDTO
                {
                    ParentID = appointment.PetParent.Id,
                    ParentName = appointment.PetParent.Name
                }
                
            };
        }

        public SymptomDTO ConvertTOSymptomDTO(Symptom symptom)
        {
            return new SymptomDTO
            {
                Id = symptom.Id,
                Name = symptom.Name, AppointmentId = symptom.AppointmentId
            };
        }

        public ICollection<SymptomDTO> ConvertToListSymptomDTO(ICollection<Symptom> symptoms)
        {
            ICollection<SymptomDTO> symptomsdto = new List<SymptomDTO>();
            foreach(var symptom in symptoms)
            {
                symptomsdto.Add(ConvertTOSymptomDTO(symptom));
            }
            return symptomsdto;
        }

        public VetDTO ConvertToVetDTO(Vet vet)
        {
            return new VetDTO
            {
                PhoneNo = vet.PhoneNo,
                Speciality = vet.Speciality,
                VetId = vet.VetId,
                VetName = vet.Name
            };
        }

        public VitalDTO ConvertToVitalDTO(Vital vital)
        {
            return new VitalDTO
            {
                Ecg = vital.ECG,
                Id = vital.Id,
                Respiration_rate = vital.RespirationRate,
                Temperature = vital.Temperature,
                AppointmentId = vital.AppointmentId
            };
        }

        public ICollection<TestDTO> ConvertToListTestDTO(ICollection<Test> tests)
        {
            ICollection<TestDTO> testDTOs = new List<TestDTO>();
            foreach(Test test in tests)
            {
                testDTOs.Add(ConvertTotestDTO(test));
            }
            return testDTOs;
        }

        public TestDTO ConvertTotestDTO(Test test)
        {
            return new TestDTO
            {
                Id = test.Id,
                Name = test.Name,AppointmentId = test.AppointmentId,
            };
        }

        public  AppointmentBasicDetailsDTO ConvertToAppointmentBasicInfoDTO(Appointment model)
        {
            AppointmentBasicDetailsDTO appointment = new AppointmentBasicDetailsDTO
            {
                AppointmentId = model.Id,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
                AppointmentStatus = model.Status.ToString(),
                PatientName = model.Pet.PetName,
                Issue = model.Issue,
            };
            return appointment;
        }

        //public  ConfirmedAppointmentDTO ConvertToConfirmedAppointmentDTO(Appointment model)
        //{
        //    ConfirmedAppointmentDTO appointment = new ConfirmedAppointmentDTO
        //    {
        //        AppointmentId = model.Id,
        //        AppointmentDate = model.AppointmentDate,
        //        AppointmentTime = model.AppointmentTime,
        //        PatientName = model.Pet.PetName,
        //        IssueName = model.Issue,
        //        DoctorName = model.VetDetails.Name,
        //        Reason = model.Reason,
        //        Status = model.Status.ToString()
        //    };
        //    return appointment;
        //}

        public AppointmentCardDTO ConvertToCardDTO(Appointment appointment)
        {
            return new AppointmentCardDTO
            {
                AppointmentId = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Gender = appointment.Pet.Gender.ToString(),
                OwnerName = appointment.PetParent.Name,
                PetDOB = appointment.Pet.DOB,
                PetName = appointment.Pet.PetName,
                PetId = appointment.Pet.PetId,
                VetId = appointment.VetDetails.VetId,
                VetName = appointment.VetDetails.Name,
                VetSpeciality = appointment.VetDetails.Speciality,
            };
        }

        public Vet ConvertToVet(VetDTO vetDTO)
        {
            return new Vet
            {
                VetId = vetDTO.VetId,
                Name = vetDTO.VetName,
                Speciality = vetDTO.Speciality,
                PhoneNo = vetDTO.PhoneNo,
            }; 
        }

        public Pet ConvertToPet(PetDTO petDTO)
        {
            return new Pet
            {
                PetId = petDTO.PetId,
                DOB = petDTO.DOB,
                Gender = petDTO.Gender.ToLower() == "male" ? Gender.MALE : Gender.FEMALE,
                PetName = petDTO.PetName
            };
        }

        public PetParent ConvertToPetparent(PetParentDTO parentDTO)
        {
            return new PetParent
            {
                PetParentId = parentDTO.ParentID,
                Name = parentDTO.ParentName
            };
        }

        public Vital ConvertToVital(VitalDTO vitaldto)
        {
            return new Vital
            {
                ECG = vitaldto.Ecg,
                Id = vitaldto.Id,
                RespirationRate = vitaldto.Respiration_rate,
                Temperature = vitaldto.Temperature,
                AppointmentId = vitaldto.AppointmentId,
            };
        }

        public Test ConvertToTest(TestDTO test)
        {
            return new Test
            {
                Id = test.Id,
                Name = test.Name,
                AppointmentId = test.AppointmentId,
            };
        } 

        public Symptom ConvertToSymptom(SymptomDTO symptom)
        {
            return new Symptom
            {
               AppointmentId = symptom.AppointmentId,
               Id =symptom.Id,
               Name = symptom.Name
            };
        }
    }
}
